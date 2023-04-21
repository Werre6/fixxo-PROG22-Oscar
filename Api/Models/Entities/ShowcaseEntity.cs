using Api.Models.DTO;

namespace Api.Models.Entities;

public class ShowcaseEntity
{
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public string Title { get; set; } = null!;
	public string Offer { get; set; } = null!;
	public string Ingress { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;


	public static implicit operator ShowcaseModelDTO(ShowcaseEntity entity)
	{
		return new ShowcaseModelDTO
		{
			Title = entity.Title,
			Offer = entity.Offer,
			Ingress = entity.Ingress,
			ImageUrl = entity.ImageUrl,
		};
	}
}
