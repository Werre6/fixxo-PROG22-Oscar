using Api.Filters;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[UseApiKey]
	[Route("api/[controller]")]
	[ApiController]
	public class ShowcaseController : ControllerBase
	{
		private readonly ShowcaseRepository _showcaseRepo;

		public ShowcaseController(ShowcaseRepository showcaseRepo)
		{
			_showcaseRepo = showcaseRepo;
		}

		[HttpGet("Latest")]
		public async Task<ActionResult> Latest()
		{
			return Ok(await _showcaseRepo.GetLatestAsync());
		}
	}
}
