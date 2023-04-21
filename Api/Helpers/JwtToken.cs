using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Helpers;

public class JwtToken
{
	private readonly IConfiguration _config;

	public JwtToken(IConfiguration config)
	{
		_config = config;
	}

	public string Generate(ClaimsIdentity claimsIdentity, DateTime expiresAt)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenDescriptor = new SecurityTokenDescriptor()
		{
			Issuer = _config.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
			Audience = _config.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
			Subject = claimsIdentity,
			Expires = expiresAt,
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
				SecurityAlgorithms.HmacSha512Signature
			)
		};

		return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
	}
}
