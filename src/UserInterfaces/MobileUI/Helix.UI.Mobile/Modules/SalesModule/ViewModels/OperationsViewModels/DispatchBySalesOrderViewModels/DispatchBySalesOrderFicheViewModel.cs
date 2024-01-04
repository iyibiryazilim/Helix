using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.SalesModule.DataStores.SalesOrderDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

public partial class DispatchBySalesOrderFicheViewModel :BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly ISalesOrderService _salesOrderService;

	public ObservableCollection<WaitingOrder> Items { get; } = new();
	public Command GetOrdersCommand { get; }

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	SalesOrderOrderBy orderBy = SalesOrderOrderBy.datedesc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 3000;

	[ObservableProperty]
	Current current;
	public DispatchBySalesOrderFicheViewModel(IHttpClientService httpClientService, ISalesOrderService salesOrderService)
	{
		_httpClientService = httpClientService;
		_salesOrderService = salesOrderService;
		GetOrdersCommand = new Command(async () => await LoadData());
	}

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetSalesOrdersAsync);

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
	async Task GetSalesOrdersAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			var result = await _salesOrderService.GetObjects(httpClient,SearchText,OrderBy, CurrentPage,PageSize);
			foreach (SalesOrder item in result.Data)
			{
				var obj = Mapping.Mapper.Map<WaitingOrder>(item);
				Items.Add(obj);
			}


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

	[RelayCommand]
	async Task LoadMoreAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage++;
			var result = await _salesOrderService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					await Task.Delay(50);
					var obj = Mapping.Mapper.Map<WaitingOrder>(item);
					Items.Add(obj);
				}
			}
			else
			{
				CurrentPage--;
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");

		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task ReloadAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage = 0;
			var result = await _salesOrderService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				foreach (var item in result.Data)
				{
					await Task.Delay(50);
					var obj = Mapping.Mapper.Map<WaitingOrder>(item);
					Items.Add(obj);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task SortAsync()
	{
		if (IsBusy) return;
		try
		{
			//string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Malzeme Kodu A-Z", "Malzeme Kodu Z-A", "Malzeme Ad A-Z", "Malzeme Ad Z-A");
			//if (!string.IsNullOrEmpty(response))
			//{
			//	CurrentPage = 0;
			//	await Task.Delay(100);
			//	switch (response)
			//	{
			//		case "Malzeme Kodu A-Z":
			//			OrderBy = PurchaseOrderLineOrderBy.productcodeasc;
			//			await ReloadAsync();
			//			break;
			//		case "Malzeme Kodu Z-A":
			//			OrderBy = PurchaseOrderLineOrderBy.productcodedesc;
			//			await ReloadAsync();
			//			break;
			//		case "Malzeme Ad A-Z":
			//			OrderBy = PurchaseOrderLineOrderBy.productnameasc;
			//			await ReloadAsync();
			//			break;
			//		case "Malzeme Ad Z-A":
			//			OrderBy = PurchaseOrderLineOrderBy.productnamedesc;
			//			await ReloadAsync();
			//			break;
			//		default:
			//			await ReloadAsync();
			//			break;

			//	}
			//}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
    async Task GoToSalesOrderLineList()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineListView)}");
    }

  
}
