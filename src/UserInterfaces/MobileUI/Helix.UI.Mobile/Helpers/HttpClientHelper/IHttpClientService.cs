namespace Helix.UI.Mobile.Helpers.HttpClientHelper;

public interface IHttpClientService
{
	HttpClient GetOrCreateHttpClient();
	string Token { get; set; }
	string BaseUri { get; set; }
}
