using Mvc.Models;

namespace Mvc.Services;

public class ProductService
{
	private readonly IConfiguration _config;

	public ProductService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<IEnumerable<CollectionItemModel>> GetAllProductsAsync()
	{
		using var http = new HttpClient();
		var result = await http.GetFromJsonAsync<IEnumerable<CollectionItemModel>>($"https://localhost:7168/api/Products/All?key={_config.GetValue<string>("ApiKey")}");
		return result!;
	}
	
	public async Task<CollectionItemModel> GetProductAsync(int id)
	{
		using var http = new HttpClient();
		var result = await http.GetFromJsonAsync<CollectionItemModel>($"https://localhost:7168/api/Products/Get?id={id}&key={_config.GetValue<string>("ApiKey")}");
		return result!;
	}

	public async Task<IEnumerable<CollectionItemModel>> GetByTagAsync(string tag)
	{
		using var http = new HttpClient();
		var result = await http.GetFromJsonAsync<IEnumerable<CollectionItemModel>>($"https://localhost:7168/api/Products/Tag?tag={tag}&key={_config.GetValue<string>("ApiKey")}");
		return result!;
	}
}
