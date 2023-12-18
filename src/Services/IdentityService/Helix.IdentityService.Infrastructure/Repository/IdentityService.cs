using Helix.IdentityService.Application.Repository;
using Helix.IdentityService.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Helix.IdentityService.Infrastructure.Repository;

public class IdentityService : IIdentityService
{
	IHttpClientFactory _httpClientFactory;
	public IdentityService(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
	{
		var loginResponseModel = new LoginResponseModel();
		//Veri tabanı veri okuma işlemi
		var httpClient = _httpClientFactory.CreateClient("wms");

		var responseMessage = await httpClient.PostAsync($"/api/Authentication/Authenticate",
			   new StringContent(JsonSerializer.Serialize(new { requestModel.UserName, requestModel.Password }), Encoding.UTF8, "application/json"));

		if (responseMessage.IsSuccessStatusCode)
		{
			if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var getToken = await responseMessage.Content.ReadAsStringAsync();
				var claims = new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier,requestModel.UserName),
					new Claim(ClaimTypes.Name,"İyibir Yazılım"),
					new Claim(ClaimTypes.Authentication,getToken)
				};

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iyibirSoftwareAndTechnologyDeveloperTeam"));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var expriy = DateTime.Now.AddDays(1);

				var token = new JwtSecurityToken(claims: claims, expires: expriy, signingCredentials: creds, notBefore: DateTime.Now);
				var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

				loginResponseModel.Token = encodedJwt;
				loginResponseModel.UserName = requestModel.UserName;
			}

		}

		return await Task.FromResult(loginResponseModel);
	}
}
