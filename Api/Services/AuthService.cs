using Api.Helpers;
using Api.Models.DTO;
using Api.Models.Entities;
using Api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Services;

public class AuthService
{
	private readonly UserProfileRepository _userProfileRepo;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly JwtToken _jwt;

	public AuthService(UserProfileRepository userProfileRepo, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtToken jwt, RoleManager<IdentityRole> roleManager)
	{
		_userProfileRepo = userProfileRepo;
		_userManager = userManager;
		_signInManager = signInManager;
		_jwt = jwt;
		_roleManager = roleManager;
	}

	public async Task<bool> RegisterAsync(RegisterModelDTO model)
	{
		try
		{
			if (!await _roleManager.Roles.AnyAsync())
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
				await _roleManager.CreateAsync(new IdentityRole("ProductManager"));
			}

			if (!await _userManager.Users.AnyAsync())
				model.RoleName = "Admin";

			var identityResult = await _userManager.CreateAsync(model, model.Password);

			if (identityResult.Succeeded)
			{
				var identityUser = await _userManager.FindByEmailAsync(model.Email);

				await _userManager.AddToRoleAsync(identityUser!, model.RoleName);

				UserProfileEntity userProfileEntity = model;
				userProfileEntity.UserId = identityUser!.Id;
				await _userProfileRepo.AddAsync(userProfileEntity);

				return true;
			}
		}
		catch { }

		return false;
	}

	public async Task<string> LoginAsync(LoginModelDTO model)
	{
		var identityUser = await _userManager.FindByEmailAsync(model.Email);
		if (identityUser != null)
		{
			var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
			if (signInResult.Succeeded)
			{
				var roles = await _userManager.GetRolesAsync(identityUser);
				var claimsIdentity = new ClaimsIdentity(new Claim[]
				{
					new Claim("id", identityUser.Id),
					new Claim(ClaimTypes.Role, roles[0]),
					new Claim(ClaimTypes.Name, identityUser.Email!)
				});

				return _jwt.Generate(claimsIdentity, DateTime.Now.AddHours(1));
			}
		}

		return string.Empty;
	}
}
