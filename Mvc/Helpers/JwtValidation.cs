using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Mvc.Helpers;

public class JwtValidation
{
	private readonly IConfiguration _config;

	public JwtValidation(IConfiguration configuration)
	{
		_config = configuration;
	}

	public bool ValidateToken(string token)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var validationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_config.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
			ValidateLifetime = true,
			ValidateIssuer = true,
			ValidIssuer = _config.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
			ValidateAudience = true,
			ValidAudience = _config.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
			ClockSkew = TimeSpan.FromSeconds(0)
		};

		try
		{
			var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

			var roleClaim = principal.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

			if (_config.GetSection("TokenValidation:ValidRoles").Get<string[]>()!.Contains(roleClaim?.Value))
				return true;
		}
		catch (SecurityTokenValidationException)
		{
		}
		catch (Exception)
		{
		}

		return false;
	}
}
