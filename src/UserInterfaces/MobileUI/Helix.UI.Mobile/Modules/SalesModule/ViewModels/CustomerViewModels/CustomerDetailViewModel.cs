using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class CustomerDetailViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;

		[ObservableProperty]
		Customer current;

		public CustomerDetailViewModel(IHttpClientService httpClientService)
		{
			Title = "Müşteri Detayı";
			_httpClientService = httpClientService;

		}

		[RelayCommand]
		async Task GoToBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
