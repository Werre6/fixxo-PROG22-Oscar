using Mvc.Models.DTO;
using System.Net.Http.Headers;

namespace Mvc.Services;

public class AdminServices
{
	private readonly IConfiguration _config;

	public AdminServices(IConfiguration config)
	{
		_config = config;
	}

	public async Task<HttpResponseMessage> AddProductAsync(CreateProductDTO dto, string token)
	{
		using var http = new HttpClient();
		http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return await http.PostAsJsonAsync($"https://localhost:7168/api/Products/Add?key={_config.GetValue<string>("ApiKey")}", dto);
	}

	public async Task<HttpResponseMessage> DeleteProductAsync(int id, string token)
	{
		using var http = new HttpClient();
		http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return await http.PostAsJsonAsync($"https://localhost:7168/api/Products/Delete?id={id}&key={_config.GetValue<string>("ApiKey")}", "");
	}
}
