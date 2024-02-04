using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.IntroductionModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Helix.UI.Mobile.Modules.LoginModule.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IAuthenticationService _authenticationService;

	[ObservableProperty]
	string userName = String.Empty;

	[ObservableProperty]
	string password = String.Empty;

    public LoginViewModel(IHttpClientService httpClientService, IAuthenticationService authenticationService)
    {
		_httpClientService = httpClientService;
		_authenticationService = authenticationService;
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

	
	[RelayCommand]
	async Task AuthenticateAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			if (!string.IsNullOrEmpty(UserName))
			{
				var httpClient = _httpClientService.GetOrCreateHttpClient();
				var auth = await _authenticationService.Authenticate(httpClient, UserName, Password);
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

				//await SecureStorage.Default.SetAsync("CurrentUser", $"");
				var result = await SecureStorage.Default.GetAsync("isWatch");
				if (result == "true")
				{
					await Task.Delay(100);
					Application.Current.MainPage = new AppShell();

				}
				else
				{
					await Task.Delay(100);
					Application.Current.MainPage = new IntroductionScreenView();
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}
	}
	
	
}


