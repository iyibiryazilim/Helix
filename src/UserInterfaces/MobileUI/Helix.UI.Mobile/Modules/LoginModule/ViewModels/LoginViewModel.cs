using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.IntroductionModule.Views;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.LoginModule.ViewModels
{
	public partial class LoginViewModel : BaseViewModel
	{
        public LoginViewModel()
        {
            
        }
        [RelayCommand]
		async Task GoToMainPage()
		{

			var result = await SecureStorage.Default.GetAsync("isWatch"); 
			if (result=="true")
			{
				Application.Current.MainPage = new AppShell();

			}
			else
			{
				Application.Current.MainPage = new IntroductionScreenView();
			}
		}
	}

	
}
