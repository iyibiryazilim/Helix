using Helix.NotificationService.Model;

namespace Helix.NotificationService.Helper
{
	public interface IAuthenticationService
	{
		Task<AuthenticateModel> Authenticate(HttpClient httpClient);

	}
}
