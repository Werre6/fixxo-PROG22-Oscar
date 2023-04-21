using Mvc.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
	public class RegisterFormViewModel
	{
		[Display(Name = "First name")]
		[Required(ErrorMessage = "This field cannot be empty")]
		[MinLength(2, ErrorMessage = "Must contain more than 2 characters")]
		public string FirstName { get; set; } = null!;

		[Display(Name = "Last name")]
		[Required(ErrorMessage = "This field cannot be empty")]
		[MinLength(2, ErrorMessage = "Must contain more than 2 characters")]
		public string LastName { get; set; } = null!;

		[Display(Name = "Email")]
		[Required(ErrorMessage = "This field cannot be empty")]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Not a valid email")]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Display(Name = "Password")]
		[Required(ErrorMessage = "This field cannot be empty")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Not a valid password")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Display(Name = "Confirm password")]
		[Required(ErrorMessage = "This field cannot be empty")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
		public string ConfirmPassword { get; set; } = null!;

		public static implicit operator RegisterModelDTO(RegisterFormViewModel model)
		{
			return new RegisterModelDTO
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Password = model.Password,
			};
		}
	}
}
