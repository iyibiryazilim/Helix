using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Models.BaseModel;
using Helix.LBSService.Tiger.Services;

namespace Helix.LBSService.Tiger.DataStores
{
	public class UnityApplicationDataStore : IUnityApplicationService
	{


		public Task<UnityResult> CompanyLogIn()
		{
			throw new NotImplementedException();
		}

		public Task<UnityResult> CompanyLogOut()
		{
			throw new NotImplementedException();
		}

		public async Task<UnityResult> LogIn()
		{
			var unity = Global.UnityApp;
			Task<UnityResult> LoginTask = Task.Run(() =>
			{
				if (!unity.LoggedIn)
				{
					if (unity.Login("LOGO", "LOGO", 8))
					{
						return new UnityResult()
						{
							IsSuccess = true,
							Message = "Succes",
							Data = true
						};
					}
					else
					{
						return new UnityResult()
						{
							IsSuccess = false,
							Message = unity.GetLastError().ToString() + ":" + unity.GetLastErrorString().ToString(),
							Data = false
						};
					}
				}
				else
				{
					return new UnityResult()
					{
						IsSuccess = true,
						Message = "Giriş yapıldı",
						Data = true
					};
				}
			});
			return await Task.FromResult(LoginTask.Result);
		}

		public async Task<UnityResult> LogOut()
		{
			Task<UnityResult> LogOutTask = Task.Run(() =>
			{
				var unity = Global.UnityApp;
				if (Global.UnityApp.LoggedIn)
				{
					Global.UnityApp.Disconnect();
					return new UnityResult()
					{
						IsSuccess = true,
						Message = "Çıkış Yapıldı",
						Data = true
					};
				}
				return new UnityResult()
				{
					IsSuccess = false,
					Message = unity.GetLastError().ToString() + ":" + unity.GetLastErrorString().ToString(),
					Data = false
				};
			});
			return await Task.FromResult(LogOutTask.Result);


		}

		public Task<UnityResult> UserLogIn()
		{
			throw new NotImplementedException();
		}

		public Task<UnityResult> UserLogOut()
		{
			throw new NotImplementedException();
		}
	}
}
