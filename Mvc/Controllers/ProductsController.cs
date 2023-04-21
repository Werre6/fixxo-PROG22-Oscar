using Microsoft.AspNetCore.Mvc;
using Mvc.Services;

namespace Mvc.Controllers;

public class ProductsController : Controller
{
	private readonly ProductService _productService;

	public ProductsController(ProductService productService)
	{
		_productService = productService;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _productService.GetAllProductsAsync());
	}

	public async Task<IActionResult> ProductDetails(int id)
	{
		return View(await _productService.GetProductAsync(id));
	}
}
