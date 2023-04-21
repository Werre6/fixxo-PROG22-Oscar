using Api.Models.Entities;

namespace Api.Models.DTO;

public class CustomerCommentDTO
{
	public string CustomerName { get; set; } = null!;
	public string CustomerEmail { get; set; } = null!;
	public string Comment { get; set; } = null!;

	public static implicit operator CustomerCommentEntity(CustomerCommentDTO dto)
	{
		return new CustomerCommentEntity
		{
			CustomerEmail = dto.CustomerEmail,
			CustomerName = dto.CustomerName,
			Comment = dto.Comment
		};
	}
}


