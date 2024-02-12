using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        string userName;
        public AppShellViewModel()
        {
            UserName = SecureStorage.Default.GetAsync("CurrentUser").Result;
        }

        //[RelayCommand]
        //async Task LogoutAsync()
        //{
        //    await SecureStorage.Default.SetAsync("CurrentUser", "");

        //    var viewModel = _serviceProvider.GetService<LoginViewModel>();
        //    Application.Current.MainPage = new LoginView(viewModel);
        //}
    }
}
