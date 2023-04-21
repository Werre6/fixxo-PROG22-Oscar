using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Entities;

public class CategoryEntity
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50)]
	public string Name { get; set; } = null!;

	public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
