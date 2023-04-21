using Microsoft.AspNetCore.Mvc;
using Mvc.Services;
using Mvc.ViewModels;

namespace Mvc.Controllers;

public class HomeController : Controller
{
	private readonly ProductService _productService;
	private readonly ShowcaseService _showcaseService;

	public HomeController(ProductService productService, ShowcaseService showcaseService)
	{
		_productService = productService;
		_showcaseService = showcaseService;
	}

	public async Task<IActionResult> Index()
	{
		var featured = await _productService.GetByTagAsync("Featured");
		var popular = await _productService.GetByTagAsync("Popular");
		var newProducts = await _productService.GetByTagAsync("New");
		var showcase = await _showcaseService.GetLatestAsync();

		HomeViewModel model = new HomeViewModel
		{
			Showcase= showcase,
			Featured = featured.Take(8),
			Popular = popular.Take(4),
			New = newProducts.Take(4)
		};

		return View(model);
	}
}
