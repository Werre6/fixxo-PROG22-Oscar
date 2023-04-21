using Mvc.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels;

public class LoginFormViewModel
{
	[Required(ErrorMessage = "This field is required")]
	public string Email { get; set; } = null!;

	[Required(ErrorMessage = "This field is required")]
	[DataType(DataType.Password)]
	public string Password { get; set; } = null!;

	public static implicit operator LoginModelDTO(LoginFormViewModel model)
	{
		return new LoginModelDTO
		{
			Email = model.Email,
			Password = model.Password
		};
	}
}
