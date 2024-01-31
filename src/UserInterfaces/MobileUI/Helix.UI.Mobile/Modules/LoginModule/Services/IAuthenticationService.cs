using Helix.UI.Mobile.Modules.LoginModule.Models;

namespace Helix.UI.Mobile.Modules.LoginModule.Services;

public interface IAuthenticationService
{
	Task<AuthenticateModel> Authenticate(HttpClient httpClient, string username, string password);
}
