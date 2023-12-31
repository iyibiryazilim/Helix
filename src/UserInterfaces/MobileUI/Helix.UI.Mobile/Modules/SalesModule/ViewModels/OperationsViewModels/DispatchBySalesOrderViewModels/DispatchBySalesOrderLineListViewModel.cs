﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

[QueryProperty(nameof(SelectedOrders), nameof(SelectedOrders))]

public partial class DispatchBySalesOrderLineListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	ISalesOrderLineService _salesOrderLineService;
	public DispatchBySalesOrderLineListViewModel(IHttpClientService httpClientService, ISalesOrderLineService salesOrderLineService)
	{
		_httpClientService = httpClientService;
		_salesOrderLineService = salesOrderLineService;
		Title = "Bekleyen Sipariş Satırları";
		GetOrderLinesCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		SelectAllCommand = new Command<bool>(async (isSelected) => await SelectAllAsync(isSelected));
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	SalesOrdersLineOrderBy orderBy = SalesOrdersLineOrderBy.duedateasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20000;

	[ObservableProperty]
	ObservableCollection<WaitingOrder> selectedOrders;
	public Command GetOrderLinesCommand { get; }
	public Command SearchCommand { get; }
	public Command SelectAllCommand { get; }

	public ObservableCollection<WaitingOrderLine> Items { get; } = new();
	public ObservableCollection<WaitingOrderLine> Results { get; } = new();
	public ObservableCollection<WaitingOrderLine> SelectedOrderLines { get; } = new();
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
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			foreach (var order in SelectedOrders)
			{
				var result = await _salesOrderLineService.GetObjectByFicheId(httpClient, true, order.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
				Items.Clear();
				Results.Clear();
				foreach (SalesOrderLine item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					obj.TempQuantity = (double)item.WaitingQuantity;

					Items.Add(obj);
					Results.Add(obj);
				}
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
					foreach (var item in Items.ToList().Where(x => x.OrderCode.Contains(SearchText) || x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
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
	async Task SortAsync()
	{
		if (IsBusy) return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Termin Tarihi Büyükten Küçüğe", "Termin Tarihi Küçükten Büyüğe");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Termin Tarihi Büyükten Küçüğe":
						Results.Clear();
						foreach (var item in Items.OrderByDescending(x => x.DueDate).ToList())
						{
							Results.Add(item);
						}
						break;
					case "Termin Tarihi Küçükten Büyüğe":
						Results.Clear();
						foreach (var item in Items.OrderBy(x => x.DueDate).ToList())
						{
							Results.Add(item);
						}
						break;
					default:
						Results.Clear();
						foreach (var item in Items)
						{
							Results.Add(item);
						}
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

	public async Task SelectAllAsync(bool isSelected)
	{
		if (isSelected)
		{
			foreach (var item in Results)
			{
				item.IsSelected = true;
				SelectedOrderLines.Add(item);

			}
		}
		else
		{
			foreach (var item in Results)
			{
				item.IsSelected = false;
				SelectedOrderLines.Remove(item);

			}
		}
	}

	[RelayCommand]
	public async Task ToggleSelectionAsync(WaitingOrderLine model)
	{
		await Task.Run(() =>
		{

			WaitingOrderLine selectedItem = Results.FirstOrDefault(x => x.ReferenceId == model.ReferenceId);
			if (selectedItem != null)
			{
				if (selectedItem.IsSelected)
				{
					selectedItem.IsSelected = false;
					SelectedOrderLines.Remove(selectedItem);

				}
				else
				{
					selectedItem.IsSelected = true;

					SelectedOrderLines.Add(selectedItem);
				}
			}

		});
	}


	[RelayCommand]
	async Task GoToSalesOrderSummary()
	{
		await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderSelectedLineListView)}", new Dictionary<string, object>
		{
			["SelectedOrderLines"] = SelectedOrderLines
		});

	}

}
