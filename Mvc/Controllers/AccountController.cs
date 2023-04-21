using Microsoft.AspNetCore.Mvc;
using Mvc.Helpers;
using Mvc.Services;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
	public class AccountController : Controller
	{
		private readonly AccountService _accountService;
		private readonly JwtValidation _jwtValidation;

		public AccountController(AccountService accountService, JwtValidation jwtValidation)
		{
			_accountService = accountService;
			_jwtValidation = jwtValidation;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.RegisterAsync(model);

				if (result.IsSuccessStatusCode)
					return RedirectToAction("Login", "Account");

				ModelState.AddModelError("", "Incorrect email or password");
			}

			return View(model);
		}

		public IActionResult Login()
		{
			var token = HttpContext.Request.Cookies["accessToken"];

			if (_jwtValidation.ValidateToken(token!))
			{
				return RedirectToAction("Logout", "Account");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountService.LoginAsync(model);

				if (result.IsSuccessStatusCode)
				{
					var token = await result.Content.ReadAsStringAsync();
					HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
					{
						HttpOnly = true,
						Secure = true,
						Expires = DateTime.Now.AddHours(1)
					});

					return RedirectToAction("Index", "Admin");
				}

				ModelState.AddModelError("", "Incorrect email or password");
			}
			return View(model);
		}

		public IActionResult Logout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Logout(string tokenName)
		{
			Response.Cookies.Delete(tokenName);

			return RedirectToAction("Index", "Home");
		}

		public IActionResult UnauthorizedAccount()
		{
			return View();
		}
	}
}
