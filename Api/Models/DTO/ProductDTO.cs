using Api.Models.Entities;

namespace Api.Models.DTO
{
	public class ProductDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public double Price { get; set; }
		public int StarRating { get; set; }
		public string Category { get; set; } = null!;
		public string Tag { get; set; } = null!;

		public string? ImageUrl { get; set; }


		public static implicit operator ProductDTO(ProductEntity entity)
		{
			return new ProductDTO
			{
				Id = entity.Id,
				Title = entity.Title,
				Description = entity.Description,
				Price = entity.Price,
				StarRating = entity.StarRating,
				Category = entity.Category.Name,
				Tag = entity.Tag.Name
			};
		}

	}
}
