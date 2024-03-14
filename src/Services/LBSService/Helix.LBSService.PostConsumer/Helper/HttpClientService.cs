namespace Helix.LBSService.PostConsumer.Helper
{
	public class HttpClientService : IHttpClientService
	{
		private readonly Lazy<HttpClient> _httpClient;
		private readonly IConfiguration _configuration;

		public HttpClientService(IConfiguration configuration)
		{
			_configuration = configuration;

			_httpClient = new Lazy<HttpClient>(() =>
			{
				var httpClient = new HttpClient();

				var baseUri = _configuration["BaseUri"]; // Retrieving BaseUri from appsettings.json
				httpClient.BaseAddress = new Uri(baseUri);
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				return httpClient;
			}, LazyThreadSafetyMode.None);
		}

		public string Token { get; set; } = string.Empty;
 
		public HttpClient GetOrCreateHttpClient()
		{
			var httpClient = _httpClient.Value;

			if (!string.IsNullOrEmpty(Token))
			{
				var token = Token.Trim('"');
				if (httpClient.DefaultRequestHeaders.Authorization == null)
					httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			}
			else
			{
				httpClient.DefaultRequestHeaders.Authorization = null;
			}

			return httpClient;
		}
	}
}