using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
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

	public ObservableCollection<SalesOrder> Items { get; } = new();
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
			await Task.WhenAll(
			  GetSalesOrdersAsync()
			);

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
				Items.Add(item);
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
    async Task GoToSalesOrderLineList()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineListView)}");
    }

  
}
