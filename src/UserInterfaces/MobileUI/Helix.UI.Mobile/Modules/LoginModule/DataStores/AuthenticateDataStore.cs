using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.LoginModule.Models;
using Helix.UI.Mobile.Modules.LoginModule.Services;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.LoginModule.DataStores;

public class AuthenticateDataStore : IAuthenticationService
{
	private readonly IHttpClientService _httpClientService;
	public AuthenticateDataStore(IHttpClientService httpClientService)
	{
		_httpClientService = httpClientService;
	}

	public async Task<AuthenticateModel> Authenticate(HttpClient httpClient, string username, string password)
	{
		AuthenticateModel authenticateModel = new();
		try
		{
			var http = _httpClientService.GetOrCreateHttpClient();

			var responseMessage = await http.PostAsync($"gateway/identity/Authentication/Authenticate",
				new StringContent(JsonSerializer.Serialize(new {username, password}), Encoding.UTF8, "application/json")); 

			if(responseMessage.IsSuccessStatusCode)
			{
				if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var token = await responseMessage.Content.ReadAsStringAsync();
					_httpClientService.Token = token;

					http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
					authenticateModel.Token = token.Trim('"');
					authenticateModel.Result = true;
					authenticateModel.Message = "Success";
				}
				else
				{
					authenticateModel.Result = false;
					authenticateModel.Message = await responseMessage.Content.ReadAsStringAsync();
				}
			}
            else
            {
				authenticateModel.Result = false;
				authenticateModel.Message = await responseMessage.Content.ReadAsStringAsync();
            }
        }
		catch(Exception ex)
		{
			authenticateModel.Result = false;
			authenticateModel.Message = ex.Message;
			Debug.WriteLine(ex.Message);
		}

		return authenticateModel;
	}
}
