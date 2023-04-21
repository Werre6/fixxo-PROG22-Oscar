using System.ComponentModel.DataAnnotations;

namespace Api.Models.Entities;

public class TagEntity
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50)]
	public string Name { get; set; } = null!;

	public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
