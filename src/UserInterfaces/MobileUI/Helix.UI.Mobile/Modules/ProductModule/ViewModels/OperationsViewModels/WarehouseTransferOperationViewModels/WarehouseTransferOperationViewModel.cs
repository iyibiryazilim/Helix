using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
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
	IWarehouseTotalService _warehouseTotalService;

	public ObservableCollection<Warehouse> WarehouseList { get; } = new();
	public ObservableCollection<WarehouseTotal> Items { get; } = new();
	public Command GetDataCommand { get; }
	public Command<string> PerformSearchCommand { get; }
	
	public WarehouseTransferOperationViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, IWarehouseTotalService warehouseTotalService)
	{
		Title = "Ambar Transfer İşlemleri";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
		_warehouseTotalService = warehouseTotalService;

		GetDataCommand  = new Command(async () => await LoadDataAsync());
	}

	[ObservableProperty]
	Warehouse selectedWarehouse;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;

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
			var result = await _warehouseService.GetObjects(httpClient, SearchText, DataStores.WarehouseDataStore.WarehouseOrderBy.numberasc, CurrentPage, 50); // 50 is  PageSize

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

	[RelayCommand]
	public async Task GetSelectedWarehouseItemsAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			//var result = await _warehouseTotalService.GetWarehouseTotals(httpClient,SelectedWarehouse.Number, "1,2,3,4,10,11,12,13")
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Shell.Current.DisplayAlert("Hata", "Seçilen ambarın ürünleri getirilirken bir hata oluştu.", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}


	/*
	[RelayCommand]
	public async Task GoToBackAsync()
	{
		try
		{
			IsBusy = true;

			if (Items.Count == 0)

				await Shell.Current.GoToAsync("..");
			else
			{
				bool answer = await Shell.Current.DisplayAlert("Uyarı", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");
				if (answer)
				{
					await Shell.Current.GoToAsync("..");
					Items.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");

		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToOperationFormAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			if(Items.Count > 0)
			{
				await Shell.Current.GoToAsync($"{nameof()}", new Dictionary<string, object>
				{
					[nameof(ProductModel)] = Items
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Form sayfasına gitmek için ürününüzün bulunması gerekmektedir", "Tamam");
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}
	}
	*/

}
