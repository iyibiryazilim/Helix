using Helix.LBSNotification.Model;

namespace Helix.LBSNotification.Helpers.AuthenticationHelper
{
    public interface IAuthenticateService
    {
        Task<AuthenticateModel> Authenticate(HttpClient httpClient);
    }
}
