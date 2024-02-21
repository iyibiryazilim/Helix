﻿namespace Helix.LBSService.PostConsumer.Helper;

public class HttpClientService : IHttpClientService
{
	private readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(
() =>
{
	var httpClient = new HttpClient();


	httpClient.BaseAddress = new Uri("http://172.25.86.101:10085");
	httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

	return httpClient;
}

, LazyThreadSafetyMode.None);

	public string Token { get; set; } = string.Empty;

	public string BaseUri { get; set; } = "http://172.25.86.101:10085";

	public HttpClient GetOrCreateHttpClient()
	{


		var httpClient = _httpClient.Value;



		if (!string.IsNullOrEmpty(Token))
		{
			var token = Token.Trim('"');
			if (httpClient.DefaultRequestHeaders.Authorization == null)
				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			else
			{
				//httpClient.DefaultRequestHeaders.Authorization.Parameter = token;
			}

		}
		else
			httpClient.DefaultRequestHeaders.Authorization = null;

		return httpClient;
	}
}