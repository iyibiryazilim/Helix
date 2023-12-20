using CommunityToolkit.Mvvm.Input;
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
			Application.Current.MainPage = new AppShell();
			//await Shell.Current.GoToAsync(nameof(AppShell));
		}
	}

	
}
