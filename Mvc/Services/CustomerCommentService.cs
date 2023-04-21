using Mvc.Models.DTO;

namespace Mvc.Services;

public class CustomerCommentService
{
	private readonly IConfiguration _config;

	public CustomerCommentService(IConfiguration config)
	{
		_config = config;
	}

	public async Task<HttpResponseMessage> PostCommentAsync(CustomerCommentDTO dto)
	{
		using var http = new HttpClient();
		var result = await http.PostAsJsonAsync($"https://localhost:7168/api/CustomerComments/Post?key={_config.GetValue<string>("ApiKey")}", dto);
		return result!;
	}
}
