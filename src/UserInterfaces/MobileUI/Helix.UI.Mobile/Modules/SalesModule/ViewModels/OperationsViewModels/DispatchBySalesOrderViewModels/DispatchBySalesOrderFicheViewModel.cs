using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.SalesModule.DataStores.SalesOrderDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

[QueryProperty(nameof(Current), nameof(Current))]

public partial class DispatchBySalesOrderFicheViewModel :BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly ISalesOrderService _salesOrderService;

	public ObservableCollection<WaitingOrder> Items { get; } = new();
	public ObservableCollection<WaitingOrder> Results { get; } = new();
	public ObservableCollection<WaitingOrder> SelectedOrders { get; } = new();


	public Command GetOrdersCommand { get; }
	public Command SearchCommand { get; }
    public Command SelectAllCommand { get; }


    [ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	SalesOrderOrderBy orderBy = SalesOrderOrderBy.datedesc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20000;

	[ObservableProperty]
	Customer current;
	public DispatchBySalesOrderFicheViewModel(IHttpClientService httpClientService, ISalesOrderService salesOrderService)
	{
		_httpClientService = httpClientService;
		_salesOrderService = salesOrderService;
		GetOrdersCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
        SelectAllCommand =new Command<bool> (async (isSelected) => await SelectAllAsync(isSelected));
        Title = "Bekleyen Satış Siparişleri";
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
            IsRefreshing = false;

        }
    }
	[RelayCommand]
	async Task GetSalesOrdersAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();

			var result = await _salesOrderService.GetObjectsByCurrentId(httpClient,Current.ReferenceId,SearchText,OrderBy, CurrentPage,PageSize);
			Items.Clear();
			Results.Clear();
			foreach (SalesOrder item in result.Data)
			{
				var obj = Mapping.Mapper.Map<WaitingOrder>(item);				 
				Items.Add(obj);
				Results.Add(obj);
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
	public async Task PerformSearchAsync(string text)
	{
		if (IsBusy)
			return;
		try
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Length >= 3)
				{
					SearchText = text;
					Results.Clear();
					foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText)||x.CurrentName.Contains(SearchText) || x.CurrentCode.Contains(SearchText)))
					{
						Results.Add(item);
					}
				}
			}
			else
			{
				SearchText = string.Empty;
				Results.Clear();
				foreach (var item in Items)
				{
					Results.Add(item);
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
			var result = await _salesOrderService.GetObjectsByCurrentId(httpClient,Current.ReferenceId ,SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				Results.Clear();
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrder>(item);
					Items.Add(obj);
					Results.Add(obj);
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarih Büyükten Küçüğe", "Tarih Küçükten Büyüğe");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Tarih Büyükten Küçüğe":
						Results.Clear();
						foreach (var item in Items.OrderByDescending(x => x.Date).ToList())
						{
							Results.Add(item);
						}
						break;
					case "Tarih Küçükten Büyüğe":
						Results.Clear();
						foreach (var item in Items.OrderBy(x => x.Date).ToList())
						{
							Results.Add(item);
						}
						break;
					default:
						await ReloadAsync();
						break;

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
	public async Task SelectAsync(WaitingOrder model)
	{
		await Task.Run(() =>
		{
			WaitingOrder selectedItem = Results.FirstOrDefault(x => x.ReferenceId == model.ReferenceId);
			if (selectedItem != null)
			{
				if (selectedItem.IsSelected)
				{
					selectedItem.IsSelected = false;
					SelectedOrders.Remove(selectedItem);

				}
				else
				{
					selectedItem.IsSelected = true;

					SelectedOrders.Add(selectedItem);
				}
			}

		});
	}

	[RelayCommand]
    async Task GoToSalesOrderLineListAsync()
    {
		await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineListView)}", new Dictionary<string, object>
		{
			["SelectedOrders"] = SelectedOrders
		});
    }


    public async Task SelectAllAsync(bool isSelected)
    {
		if (isSelected)
		{
			foreach (var item in Results)
			{
				item.IsSelected = true;
			}
		}
		else
		{
            foreach (var item in Results)
            {
                item.IsSelected = false;
            }
        }
    }


}
