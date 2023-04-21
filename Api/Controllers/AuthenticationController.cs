using Api.Filters;
using Api.Models.DTO;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[UseApiKey]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly AuthService _authService;

		public AuthenticationController(AuthService authService)
		{
			_authService = authService;
		}

		[Route("Register")]
		[HttpPost]
		public async Task<IActionResult> Register(RegisterModelDTO model)
		{
			if (ModelState.IsValid)
			{
				if (await _authService.RegisterAsync(model))
					return Created("", null);
			}

			return BadRequest();
		}

		[Route("Login")]
		[HttpPost]
		public async Task<IActionResult> Login(LoginModelDTO model)
		{
			if (ModelState.IsValid)
			{
				var token = await _authService.LoginAsync(model);
				if (!string.IsNullOrEmpty(token))
					return Ok(token);
			}

			return BadRequest("Incorrect email or password");
		}
	}
}
