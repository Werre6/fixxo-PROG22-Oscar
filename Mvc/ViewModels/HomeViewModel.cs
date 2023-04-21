using Api.Models.DTO;
using Mvc.Models;

namespace Mvc.ViewModels;

public class HomeViewModel
{
	public ShowcaseModelDTO Showcase { get; set; } = null!;
	public IEnumerable<CollectionItemModel> Featured { get; set; } = new List<CollectionItemModel>();
	public IEnumerable<CollectionItemModel> Popular { get; set; } = new List<CollectionItemModel>();
	public IEnumerable<CollectionItemModel> New { get; set; } = new List<CollectionItemModel>();
}
