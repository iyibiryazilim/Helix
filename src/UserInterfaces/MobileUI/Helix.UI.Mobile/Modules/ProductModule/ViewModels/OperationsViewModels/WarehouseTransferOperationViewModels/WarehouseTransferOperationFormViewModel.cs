using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

public partial class WarehouseTransferOperationFormViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseService _warehouseService;
	ISupplierService _supplierService;

	public ObservableCollection<Warehouse> WarehouseList { get; } = new();
	public ObservableCollection<Supplier> SupplierList { get; } = new();

	public Command GetItemsCommand { get; }

	public WarehouseTransferOperationFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISupplierService supplierService)
	{
		Title = "Ambar Transfer Formu";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
		_supplierService = supplierService;

		GetItemsCommand = new Command(async () => await LoadData());
	}

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await Task.WhenAll(GetWarehouseListAsync(), GetSupplierListAsync());
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20000;
	[ObservableProperty]
	WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
	[ObservableProperty]
	SupplierOrderBy supplierOrderBy = SupplierOrderBy.nameasc;



	[RelayCommand]
	public async Task GetWarehouseListAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _warehouseService.GetObjects(httpClient, SearchText, WarehouseOrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				WarehouseList.Clear();
				foreach (var item in result.Data)
				{
					WarehouseList.Add(item);
				}
			}


		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	public async Task GetSupplierListAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _supplierService.GetObjects(httpClient, SearchText, SupplierOrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				SupplierList.Clear();
				foreach (var item in result.Data)
				{
					SupplierList.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		finally
		{
			IsBusy = false;
		}
	}
}
