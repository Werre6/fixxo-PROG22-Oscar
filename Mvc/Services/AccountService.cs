using Mvc.Models.DTO;

namespace Mvc.Services;

public class AccountService
{
	private readonly IConfiguration _config;

	public AccountService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<HttpResponseMessage> RegisterAsync(RegisterModelDTO dto)
	{
		using var http = new HttpClient();
		return await http.PostAsJsonAsync($"https://localhost:7168/api/Authentication/Register?key={_config.GetValue<string>("ApiKey")}", dto);
	}

	public async Task<HttpResponseMessage> LoginAsync(LoginModelDTO dto)
	{
		using var http = new HttpClient();
		return await http.PostAsJsonAsync($"https://localhost:7168/api/Authentication/Login?key={_config.GetValue<string>("ApiKey")}", dto);
	}
}
