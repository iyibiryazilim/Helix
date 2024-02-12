using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MessageHelper;
using Helix.UI.Mobile.Modules.IntroductionModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.Services;
using Helix.UI.Mobile.Modules.LoginModule.ViewModels.BottomSheetViewModels;
using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.Views.BottomSheetViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Helix.UI.Mobile.Modules.LoginModule.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IAuthenticationService _authenticationService;
	IServiceProvider _serviceProvider;

	[ObservableProperty]
	string userName = String.Empty;

	[ObservableProperty]
	string password = String.Empty;

    public LoginViewModel(IHttpClientService httpClientService, IAuthenticationService authenticationService, IServiceProvider serviceProvider)
    {
		_httpClientService = httpClientService;
		_authenticationService = authenticationService;
		_serviceProvider = serviceProvider;
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
				string baseAddress = await SecureStorage.GetAsync("BaseUrl");
				//httpClient.BaseAddress = new Uri(baseAddress);

				var auth = await _authenticationService.Authenticate(httpClient, UserName, Password);
				if(auth.Result != false)
				{
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

					await SecureStorage.SetAsync("CurrentUser", UserName);
					var result = await SecureStorage.Default.GetAsync("isWatch");
					if (result == "true")
					{
						await Task.Delay(1000);
                        UserName = await SecureStorage.GetAsync("CurrentUser");

                        Application.Current.MainPage = new AppShell();

                    }
                    else
					{
						await Task.Delay(1000);
						Application.Current.MainPage = new IntroductionScreenView();
					}
				}
				else
				{
					MessageHelper messageHelper = new();
					CancellationTokenSource cancellationTokenSource = new();

					await messageHelper.GetToastMessage("Kullanıcı bilgileriniz hatalı!").Show(cancellationTokenSource.Token);
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

	[RelayCommand]
	async Task GoToConfigBottomSheetViewAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			ConfigBottomSheetViewModel viewModel = _serviceProvider.GetService<ConfigBottomSheetViewModel>();

			ConfigBottomSheetView bottomSheet = new ConfigBottomSheetView(viewModel);
			await bottomSheet.ShowAsync();

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

	[RelayCommand]
	async Task LogOutAsync()
	{
        await SecureStorage.SetAsync("CurrentUser", "");
        Application.Current.MainPage = new LoginView(this);
    }
	
	
}


