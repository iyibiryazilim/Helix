using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

public partial class WarehouseTransferOperationViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseService _warehouseService;

	public ObservableCollection<Warehouse> WarehouseList { get; } = new();
	public Command GetDataCommand { get; }
	
	public WarehouseTransferOperationViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
	{
		Title = "Ambar Transfer İşlemleri";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;

		GetDataCommand  = new Command(async () => await LoadDataAsync());
	}

	[ObservableProperty]
	Warehouse selectedWarehouse;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 50;

	async Task LoadDataAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	public async Task GetWarehousesAsync()
	{
		//if(IsBusy)
		//	return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _warehouseService.GetObjects(httpClient, SearchText, DataStores.WarehouseDataStore.WarehouseOrderBy.numberasc, CurrentPage, PageSize);

			if(result.Data.Any())
			{
				WarehouseList.Clear();
				foreach(var item in result.Data)
				{
					await Task.Delay(100);
					WarehouseList.Add(item);
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Shell.Current.DisplayAlert("Hata", "Ambarlar getirilirken bir hata oluştu.", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
}
