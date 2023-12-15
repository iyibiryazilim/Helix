using Helix.IdentityService.Application.Repository;
using Helix.IdentityService.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helix.IdentityService.Infrastructure.Repository;

public class IdentityService : IIdentityService
{
	public Task<LoginResponseModel> Login(LoginRequestModel requestModel)
	{
		//Veri tabanı veya appsettingsten veri okuma işlemi
		var claims = new Claim[]
		{
			new Claim(ClaimTypes.NameIdentifier,requestModel.UserName),
			new Claim(ClaimTypes.Name,"İyibir Yazılım")
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var expriy = DateTime.Now.AddDays(1);

		var token = new JwtSecurityToken(claims: claims, expires: expriy, signingCredentials: creds, notBefore: DateTime.Now);
		var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

		LoginResponseModel responseModel = new()
		{
			UserName = requestModel.UserName,
			Token = encodedJwt,
		};
		return Task.FromResult(responseModel);
	}
}
