namespace Helix.LBSNotification.Helpers.HttpClientHelper
{
    public interface IHttpClientService
    {
        HttpClient GetOrCreateHttpClient();

        string Token { get; set; }
    }
}
