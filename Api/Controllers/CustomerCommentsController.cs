using Api.Filters;
using Api.Models.DTO;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[UseApiKey]
[Route("api/[controller]")]
[ApiController]
public class CustomerCommentsController : ControllerBase
{
	private readonly CustomerCommentRepository _repository;

	public CustomerCommentsController(CustomerCommentRepository repository)
	{
		_repository = repository;
	}

	[Route("Post")]
	[HttpPost]
	public async Task<IActionResult> PostComment(CustomerCommentDTO dto)
	{
		await _repository.AddAsync(dto);
		return Created("", null);
	}
}
