using Api.Models.DTO;

namespace Mvc.Services;

public class ShowcaseService
{
	private readonly IConfiguration _config;

	public ShowcaseService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<ShowcaseModelDTO> GetLatestAsync()
	{
		using var http = new HttpClient();
		var result = await http.GetFromJsonAsync<ShowcaseModelDTO>($"https://localhost:7168/api/Showcase/Latest?key={_config.GetValue<string>("ApiKey")}");
		return result!;
	}
}
