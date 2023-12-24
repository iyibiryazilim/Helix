using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
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
		IServiceProvider _serviceProvider;

		//public Command GetWarehouseDetailCommand { get; }

		[ObservableProperty]
		Warehouse warehouse;

		public WarehouseDetailViewModel(IHttpClientService httpClientService,IWarehouseService warehouseService,IServiceProvider serviceProvider)
        {
			Title = "Ambar Detayı";
            _httpClientService = httpClientService;
			_warehouseService = warehouseService;
			_serviceProvider = serviceProvider;
			
		}

		[RelayCommand]
		async Task GoToBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		async Task GoToWarehouseDetailBottomSheet()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;
				WarehouseDetailBottomSheetViewModel model = _serviceProvider.GetService<WarehouseDetailBottomSheetViewModel>();
				model.Warehouse = Warehouse;

				WarehouseDetailBottomSheetView sheet = new WarehouseDetailBottomSheetView(model);
				
				await sheet.ShowAsync();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}

		}


	}
}
