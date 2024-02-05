using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MessageHelper;
using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.Views.BottomSheetViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.LoginModule.ViewModels.BottomSheetViewModels;

public partial class ConfigBottomSheetViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	public ConfigBottomSheetViewModel(IHttpClientService httpClient)
	{
		Title = "Api Parametreleri";
		_httpClient = httpClient;
	    BaseUrl = "http://195.142.192.18:1089";
	}

	[ObservableProperty]
	string baseUrl;       // baseUri + Port

	[ObservableProperty]
	string baseUri = string.Empty;

	[ObservableProperty]
	string port = string.Empty;

	
	[RelayCommand]
	async Task SaveConfigAsync()
	{
		try
		{
			IsBusy = true;

			if (!string.IsNullOrEmpty(BaseUri) && !string.IsNullOrEmpty(Port))
			{
				await SecureStorage.SetAsync("BaseUrl", $"http://{BaseUri}:{Port}");
				BaseUrl = await SecureStorage.GetAsync("BaseUrl");

				_httpClient.BaseUri = BaseUrl;
			}
			else
			{
				MessageHelper messageHelper = new();
				CancellationTokenSource cancellationTokenSource = new();

				await messageHelper.GetToastMessage("Lütfen tüm alanları doldurunuz!").Show(cancellationTokenSource.Token);
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
