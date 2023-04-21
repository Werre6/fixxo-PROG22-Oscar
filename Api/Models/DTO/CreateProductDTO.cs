using Api.Models.Entities;

namespace Api.Models.DTO
{
	public class CreateProductDTO
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public double Price { get; set; }
		public int StarRating { get; set; }
		public string Category { get; set; } = null!;
		public string Tag { get; set; } = null!;

		public static implicit operator ProductEntity(CreateProductDTO dto)
		{
			return new ProductEntity
			{
				Title = dto.Title,
				Description = dto.Description,
				Price = dto.Price,
				StarRating = dto.StarRating,
			};
		}
	}
}
