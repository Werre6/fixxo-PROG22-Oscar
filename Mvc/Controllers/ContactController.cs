using Microsoft.AspNetCore.Mvc;
using Mvc.Services;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
	public class ContactController : Controller
	{
		private readonly CustomerCommentService _customerCommentService;

		public ContactController(CustomerCommentService customerCommentService)
		{
			_customerCommentService = customerCommentService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactFormViewModel model)
		{
			if(ModelState.IsValid)
			{
				var result = await _customerCommentService.PostCommentAsync(model);

				if(result.StatusCode == System.Net.HttpStatusCode.Created)
				{
					ModelState.Clear();
					model = new ContactFormViewModel()
					{
						ConfirmationMessage = "Your comment has been posted!"
					};

					return View(model);
				}

				model.ConfirmationMessage = "Something has gone wrong, try again.";

				return View(model);
			}

			return View(model);
		} 
	}
}
