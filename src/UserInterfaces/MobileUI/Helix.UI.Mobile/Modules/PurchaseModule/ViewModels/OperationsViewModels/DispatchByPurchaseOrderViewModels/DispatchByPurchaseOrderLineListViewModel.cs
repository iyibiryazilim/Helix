﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(SelectedOrders), nameof(SelectedOrders))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(Current), nameof(Current))]

	public partial class DispatchByPurchaseOrderLineListViewModel : BaseViewModel
    {
		IPurchaseOrderLineService _purchaseOrderLineService;
		IHttpClientService _httpClientService;
		IWarehouseTotalService _warehouseTotalService;
		IServiceProvider _serviceProvider;
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		PurchaseOrderLineOrderBy orderBy = PurchaseOrderLineOrderBy.dateasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20000;

		public ObservableCollection<WaitingOrderLineGroup> WaitingOrderLineGroupList { get; } = new();
		public ObservableCollection<WaitingOrderLineGroup> Result { get; } = new();
		public ObservableCollection<WaitingOrderLineGroup> SelectedWaitingOrderLineGroupList { get; } = new();
		public ObservableCollection<WaitingOrderLine> Lines { get; } = new();
		public ObservableCollection<WaitingOrderLine> ChangedLines { get; } = new();

		public ObservableCollection<WarehouseTotal> WarehouseTotalList { get; } = new();
		[ObservableProperty]
		ObservableCollection<WaitingOrder> selectedOrders;
		[ObservableProperty]
		Warehouse warehouse;

		[ObservableProperty]
		Supplier current;
		public Command GetOrderLinesCommand { get; }
		public Command SearchCommand { get; }
		public Command SelectAllCommand { get; }

		public DispatchByPurchaseOrderLineListViewModel(IPurchaseOrderLineService purchaseOrderLineService, IHttpClientService httpClientService, IWarehouseTotalService warehouseTotalService, IServiceProvider serviceProvider)
		{
			Title = "Satır Seçimi";

			_purchaseOrderLineService = purchaseOrderLineService;
			_httpClientService = httpClientService;
			_warehouseTotalService = warehouseTotalService;
			_serviceProvider = serviceProvider;


			GetOrderLinesCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
			SelectAllCommand = new Command<bool>(async (isSelected) => await SelectAllAsync(isSelected));


		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetLinesAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		} 
		[RelayCommand]
		public async Task GetLinesAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();

				await GetWarehouseTotalAsync(httpClient);
				await GetLinesFromFiche(httpClient);
				await SetGroupLinesByProduct();
				await FIFOCalculate();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
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
				IEnumerable<WaitingOrderLineGroup> itemsToSearch = string.IsNullOrEmpty(SearchText)
					? WaitingOrderLineGroupList
					: WaitingOrderLineGroupList.Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText));

				foreach (var item in itemsToSearch)
				{
					var selectCheck = SelectedWaitingOrderLineGroupList.Where(x => x.Code == item.Code);
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
						foreach (var line in item.WaitingOrderLines)
						{
							line.IsSelected = true;
						}


						SelectedWaitingOrderLineGroupList.Add(item);
					}
				}
			}
			else
			{
				foreach (var item in Result)
				{
					item.IsSelected = false;
					foreach (var line in item.WaitingOrderLines)
					{
						line.IsSelected = false;
					}
					SelectedWaitingOrderLineGroupList.Remove(item);

				}
			}
		}

		[RelayCommand]
		public async Task ToggleSelectionAsync(WaitingOrderLineGroup model)
		{
			var selectedItem = Result.FirstOrDefault(x => x.Code == model.Code);
			if (selectedItem != null && selectedItem.IsEnabled)
			{
				if (selectedItem.IsSelected)
				{
					selectedItem.IsSelected = false;
					foreach (var line in selectedItem.WaitingOrderLines)
					{
						line.IsSelected = false;
					}
					SelectedWaitingOrderLineGroupList.Remove(selectedItem);
				}
				else
				{
					selectedItem.IsSelected = true;
					foreach (var line in selectedItem.WaitingOrderLines)
					{
						line.IsSelected = true;
					}
					SelectedWaitingOrderLineGroupList.Add(selectedItem);
				}
			}
		}
		[RelayCommand]
		public async Task OpenBottomSheetAsync(WaitingOrderLineGroup model)
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				var thisModel = WaitingOrderLineGroupList.Where(x => x.Code == model.Code).FirstOrDefault();
				DispatchByPurchaseOrderChangeViewModel viewModel = _serviceProvider.GetService<DispatchByPurchaseOrderChangeViewModel>();
				DispatchByPurchaseOrderChangeBottomSheetView sheet = new(viewModel);
				viewModel.LineGroup = thisModel;
				await sheet.ShowAsync();
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
		async Task GetWarehouseTotalAsync(HttpClient httpClient)
		{
			try
			{
				WarehouseTotalList.Clear(); 

				var warehouseNumber = Warehouse.Number;

				var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, (int)warehouseNumber, "1,2,3,4,10,11,12,13", "", WarehouseTotalOrderBy.nameasc, 0, 10000);
				if (result.IsSuccess)
				{
					WarehouseTotalList.Clear(); 
					foreach (var item in result.Data)
					{
						WarehouseTotalList.Add(item);
					}
				}
				else
				{
					await Shell.Current.DisplayAlert(" Error: ", $"{result.Message}", "Tamam");

				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
		}
		async Task GetLinesFromFiche(HttpClient httpClient)
		{
			try
			{
 
				foreach (var order in SelectedOrders)
				{
					var salesResult = await _purchaseOrderLineService.GetWaitingOrderByCode(httpClient, SearchText, OrderBy,order.Code , CurrentPage, PageSize);
 					if (salesResult.IsSuccess)
					{
						Lines.Clear();
						foreach (var item in salesResult.Data)
						{
							var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
							obj.TempQuantity = (double)item.WaitingQuantity;

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
					WaitingOrderLineGroupList.Clear();
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
									WaitingOrderLineGroup model = new();
									model.Code = product.ProductCode;
									model.SubUnitsetCode = product.SubUnitsetCode;
									model.Name = product.ProductName;
									model.StockQuantity = product.OnHand;
									model.IsEnabled = false;
									foreach (var it in item.ToList())
									{
										model.WaitingOrderLines.Add(it);
										if (model.LineQuantity + it.WaitingQuantity > model.StockQuantity)
										{
											model.LineQuantity = model.StockQuantity;
										}
										else
										{
											model.LineQuantity += it.WaitingQuantity;
										}
									}
									WaitingOrderLineGroupList.Add(model);
									Result.Add(model);
								}
								else
								{
									WaitingOrderLineGroup model = new();
									model.Code = product.ProductCode;
									model.SubUnitsetCode = product.SubUnitsetCode;
									model.Name = product.ProductName;
									model.StockQuantity = product.OnHand;
									model.IsEnabled = true;
									foreach (var it in item.ToList())
									{
										model.WaitingOrderLines.Add(it);
										if (model.LineQuantity + it.WaitingQuantity > model.StockQuantity)
										{
											model.LineQuantity = model.StockQuantity;
										}
										else
										{
											model.LineQuantity += it.WaitingQuantity;
										}
									}
									WaitingOrderLineGroupList.Add(model);
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
		async Task FIFOCalculate()
		{
			try
			{
				foreach (var item in WaitingOrderLineGroupList)
				{
					var tempQuantity = (double?)item.StockQuantity;
					item.WaitingOrderLines.OrderBy(x => x.DueDate);
					foreach (var lines in item.WaitingOrderLines)
					{
						if (tempQuantity > 0)
						{
							if (tempQuantity - lines.WaitingQuantity < 0)
							{
								lines.FifoQuantity = tempQuantity;
								tempQuantity = 0;
							}
							else
							{
								tempQuantity -= lines.WaitingQuantity;
								lines.FifoQuantity = lines.WaitingQuantity;
							}
						}
						else
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		async Task GoToSummaryAsync()
		{
			if (IsBusy)
				return;

			try
			{
				if (SelectedWaitingOrderLineGroupList.Count > 0)
				{
					foreach (var item in SelectedWaitingOrderLineGroupList)
					{
						foreach (var line in item.WaitingOrderLines)
						{
							if (line.FifoQuantity > 0)
							{
								ChangedLines.Add(line);
							}
						}
					}
					await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderSummaryView)}", new Dictionary<string, object>
					{
						[nameof(ChangedLines)] = ChangedLines,
						[nameof(Warehouse)] = Warehouse,
						[nameof(Current)] = Current
					});
				}
				else
				{
					await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
				} 
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}

		}

 	}
}
