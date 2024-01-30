using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IUnityApplicationService
	{
		Task<UnityResult> LogIn();
		Task<UnityResult> LogOut();
		Task<UnityResult> CompanyLogIn();
		Task<UnityResult> CompanyLogOut();
		Task<UnityResult> UserLogIn();
		Task<UnityResult> UserLogOut();
	}
}
