using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class CustomerDetailViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ICustomQueryService _services;

		[ObservableProperty]
		Customer current;

 		public CustomerDetailViewModel(IHttpClientService httpClientService, ICustomQueryService services)
		{
			Title = "Müşteri Detayı";
			_httpClientService = httpClientService;
			_services = services;

		}

		[RelayCommand]
		async Task GoToBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}
	}
}
