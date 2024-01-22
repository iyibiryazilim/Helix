﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
	[QueryProperty(nameof(SelectedTransactions), nameof(SelectedTransactions))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]

	public partial class ReturnByPurchaseDispatchTransactionLineListViewModel : BaseViewModel
	{

		IHttpClientService _httpClientService;
		IPurchaseDispatchTransactionLineService _purchaseDispatchTransactionLineService;
		IWarehouseTotalService _warehouseTotalService;
		public ReturnByPurchaseDispatchTransactionLineListViewModel(IHttpClientService httpClientService, IPurchaseDispatchTransactionLineService purchaseDispatchTransactionLineService, IWarehouseTotalService warehouseTotalService)
		{
			_httpClientService = httpClientService;
			_purchaseDispatchTransactionLineService = purchaseDispatchTransactionLineService;
			_warehouseTotalService = warehouseTotalService;
			Title = "İrsaliye Satırları";
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
		Warehouse warehouse;
		public ObservableCollection<DispatchTransactionLineGroup> DispatchTransactionLineGroupList { get; } = new();
		public ObservableCollection<DispatchTransactionLineGroup> Result { get; } = new();
		public ObservableCollection<DispatchTransactionLineGroup> SelectedDispatchTransactionLineGroupList { get; } = new();
		public ObservableCollection<DispatchTransactionLine> Lines { get; } = new();
		public ObservableCollection<WarehouseTotal> WarehouseTotalList { get; } = new();
		[ObservableProperty]
		ObservableCollection<DispatchTransaction> selectedTransactions;
		public Command GetOrderLinesCommand { get; }
		public Command SearchCommand { get; }
		public Command SelectAllCommand { get; }
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


				await GetWarehouseTotalAsync(httpClient);
				await GetLinesFromFiche(httpClient);
				await SetGroupLinesByProduct();
 
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
			{
				return;
			}

			try
			{
				IsBusy = true;
				SearchText = string.IsNullOrEmpty(text) ? string.Empty : text;

				Result.Clear();
				IEnumerable<DispatchTransactionLineGroup> itemsToSearch = string.IsNullOrEmpty(SearchText)
					? DispatchTransactionLineGroupList
					: DispatchTransactionLineGroupList.Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText));

				foreach (var item in itemsToSearch)
				{
					var selectCheck = SelectedDispatchTransactionLineGroupList.Where(x => x.Code == item.Code);
					Result.Add(selectCheck.Any() ? selectCheck.First() : item);
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
					//switch (response)
					//{
					//	case "Termin Tarihi Büyükten Küçüğe":
					//		Result.Clear();
					//		foreach (var item in WaitingOrderLineGroupList.OrderByDescending(x => x.DueDate).ToList())
					//		{
					//			Result.Add(item);
					//		}
					//		break;
					//	case "Termin Tarihi Küçükten Büyüğe":
					//		Result.Clear();
					//		foreach (var item in WaitingOrderLineGroupList.OrderBy(x => x.DueDate).ToList())
					//		{
					//			Result.Add(item);
					//		}
					//		break;
					//	default:
					//		Result.Clear();
					//		foreach (var item in Lines)
					//		{
					//			Result.Add(item);
					//		}
					//		break;

					//}
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
				foreach (var item in Result)
				{
					if (item.IsEnabled)
					{
						item.IsSelected = true;
						foreach (var line in item.Lines)
						{
							line.IsSelected = true;
						}


						SelectedDispatchTransactionLineGroupList.Add(item);
					}
				}
			}
			else
			{
				foreach (var item in Result)
				{
					item.IsSelected = false;
					foreach (var line in item.Lines)
					{
						line.IsSelected = false;
					}
					SelectedDispatchTransactionLineGroupList.Remove(item);

				}
			}
		}

		[RelayCommand]
		public async Task ToggleSelectionAsync(DispatchTransactionLineGroup model)
		{
			var selectedItem = Result.FirstOrDefault(x => x.Code == model.Code);
			if (selectedItem != null && selectedItem.IsEnabled)
			{
				if (selectedItem.IsSelected)
				{
					selectedItem.IsSelected = false;
					foreach (var line in selectedItem.Lines)
					{
						line.IsSelected = false;
					}
					SelectedDispatchTransactionLineGroupList.Remove(selectedItem);
				}
				else
				{
					selectedItem.IsSelected = true;
					foreach (var line in selectedItem.Lines)
					{
						line.IsSelected = true;
					}
					SelectedDispatchTransactionLineGroupList.Add(selectedItem);
				}
			}
		}

		async Task GetWarehouseTotalAsync(HttpClient httpClient)
		{
			try
			{
				WarehouseTotalList.Clear();

				var warehouseNumber = Warehouse.Number;

				var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, (int)warehouseNumber, "1,2,3,4,10,11,12,13", "", WarehouseTotalOrderBy.nameasc, 0, 10000);
				foreach (var item in result.Data)
				{
					WarehouseTotalList.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
		}
		async Task GetLinesFromFiche(HttpClient httpClient)
		{
			try
			{
				Lines.Clear();

				foreach (var order in SelectedTransactions)
				{
					var salesResult = await _purchaseDispatchTransactionLineService.GetByFicheNo(httpClient,order.Code);
					if (salesResult.IsSuccess)
					{
						foreach (var item in salesResult.Data)
						{
							var obj = Mapping.Mapper.Map<DispatchTransactionLine>(item); 
							Lines.Add(obj);
						}
					}
					else
					{
						Debug.WriteLine(salesResult.Message);
						await Shell.Current.DisplayAlert("  Error: ", $"{salesResult.Message}", "Tamam");
					}

				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
		}
		async Task SetGroupLinesByProduct()
		{
			await Task.Run(async () =>
			{

				try
				{
					var groupingLines = Lines.GroupBy(x => x.ProductCode);
					DispatchTransactionLineGroupList.Clear();
					Result.Clear();
					foreach (var item in groupingLines)
					{
						var product = WarehouseTotalList.Where(x => x.ProductCode == item.Key).FirstOrDefault();
						if (product != null)
						{
							if (product.OnHand != 0)
							{
								if (product.OnHand < 0)
								{
									DispatchTransactionLineGroup model = new();
									model.Code = product.ProductCode;
									model.SubUnitsetCode = product.SubUnitsetCode;
									model.Name = product.ProductName;
									model.StockQuantity = product.OnHand;
									model.IsEnabled = false;
									foreach (var it in item.ToList())
									{
										model.Lines.Add(it); 
									}
									DispatchTransactionLineGroupList.Add(model);
									Result.Add(model);
								}
								else
								{
									DispatchTransactionLineGroup model = new();
									model.Code = product.ProductCode;
									model.SubUnitsetCode = product.SubUnitsetCode;
									model.Name = product.ProductName;
									model.StockQuantity = product.OnHand;
									model.IsEnabled = true;
									foreach (var it in item.ToList())
									{
										model.Lines.Add(it);
									}
									DispatchTransactionLineGroupList.Add(model);
									Result.Add(model);

								}
							}
						}
					}
					Debug.WriteLine("tamanlandı.");

				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
					await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
				}
			});
		}
 
		[RelayCommand]
		async Task GoToSelectedLinesAsync()
		{
			if (SelectedDispatchTransactionLineGroupList.Count > 0)
			{
				await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderSelectedLineListView)}", new Dictionary<string, object>
				{
					[nameof(SelectedDispatchTransactionLineGroupList)] = SelectedDispatchTransactionLineGroupList
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
			}

		}
	}
}