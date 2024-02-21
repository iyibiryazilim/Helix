namespace Helix.NotificationService.Helper
{
	public interface IHttpClientService
	{
		HttpClient GetOrCreateHttpClient();
		string Token { get; set; }
		string BaseUri { get; set; }
	}
}
