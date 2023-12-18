namespace Helix.UI.Mobile.Helpers.HttpClientHelper;

public class HttpClientService : IHttpClientService
{
	private readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(
() =>
{
   var httpClient = new HttpClient();

   string uri = SecureStorage.Default.GetAsync("baseUri").Result;

   if (uri == null)
   {
	   httpClient.BaseAddress = new Uri("");
   }
   else
   {
	   httpClient.BaseAddress = new Uri(uri);
   }

   httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

   return httpClient;
}

, LazyThreadSafetyMode.None);

	public string Token { get; set; } = string.Empty;

	public string BaseUri { get; set; } = "http://195.142.192.18:1089";

	public HttpClient GetOrCreateHttpClient()
	{
		var httpClient = _httpClient.Value;



		if (!string.IsNullOrEmpty(Token))
		{
			if (httpClient.DefaultRequestHeaders.Authorization == null)
				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.Trim('"'));

		}
		else
			httpClient.DefaultRequestHeaders.Authorization = null;

		return httpClient;
	}
}
