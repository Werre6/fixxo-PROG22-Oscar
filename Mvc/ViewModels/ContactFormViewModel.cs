using Mvc.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels;

public class ContactFormViewModel
{
	[Required(ErrorMessage = "You have to enter your name")]
	[MinLength(2, ErrorMessage = "Must contain more than 2 characters")]

	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "You have to enter your email")]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Not a valid email")]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "You have to post a comment")]
	public string Comment { get; set; } = null!;

	public string ConfirmationMessage { get; set; } = "";

	public static implicit operator CustomerCommentDTO(ContactFormViewModel model)
	{
		return new CustomerCommentDTO
		{
			CustomerName = model.Name,
			CustomerEmail = model.Email,
			Comment = model.Comment,
		};
	}
}
