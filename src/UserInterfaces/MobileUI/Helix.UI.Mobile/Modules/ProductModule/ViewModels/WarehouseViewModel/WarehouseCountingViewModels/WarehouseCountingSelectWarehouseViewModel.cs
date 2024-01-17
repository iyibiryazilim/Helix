using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

public partial class WarehouseCountingSelectWarehouseViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseService _warehouseService;
	public WarehouseCountingSelectWarehouseViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
	{
		Title = "Ambar Listesi";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
	}

	#region Lists
	public ObservableCollection<Warehouse> Items { get; } = new();
	public ObservableCollection<Warehouse> Results { get; } = new();
	#endregion

	#region Commands
	public Command GetWarehousesListCommand { get; }
	public Command SearchCommand { get; }
	#endregion

	#region Properties
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseOrderBy orderBy = WarehouseOrderBy.numberasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 1000;
	[ObservableProperty]
	Warehouse selectedWarehouse;
	#endregion

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			//await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;

		}
	}

	async Task GetWarehousesAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();


			var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				Results.Clear();

				foreach (Warehouse item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

}
