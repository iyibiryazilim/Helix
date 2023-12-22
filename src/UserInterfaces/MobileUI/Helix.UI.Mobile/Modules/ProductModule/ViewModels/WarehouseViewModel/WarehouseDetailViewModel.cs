using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;
using System.Net.Http;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel
{
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]

	public partial class WarehouseDetailViewModel : BaseViewModel
	{

		IHttpClientService _httpClientService;
		private readonly IWarehouseService _warehouseService;

		//public Command GetWarehouseDetailCommand { get; }

		[ObservableProperty]
		Warehouse warehouse;

		public WarehouseDetailViewModel(IHttpClientService httpClientService,IWarehouseService warehouseService)
        {
			Title = "Ambar Detayı";
            _httpClientService = httpClientService;
			_warehouseService = warehouseService;
			
		}

		[RelayCommand]
		async Task GoToBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}




	}
}
