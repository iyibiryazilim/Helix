namespace Helix.LBSService.PostConsumer.Helper
{
	public interface IHttpClientService
	{
		HttpClient GetOrCreateHttpClient();
		string Token { get; set; }
		string BaseUri { get; set; }
	}
}
