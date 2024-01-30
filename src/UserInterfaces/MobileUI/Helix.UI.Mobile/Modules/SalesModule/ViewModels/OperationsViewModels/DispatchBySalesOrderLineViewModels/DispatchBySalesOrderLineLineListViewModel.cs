using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels
{
	[QueryProperty(name: nameof(Current), queryId: nameof(Current))]
	[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
    [QueryProperty(name: nameof(ShipInfo), queryId: nameof(ShipInfo))]

    public partial class DispatchBySalesOrderLineLineListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ISalesOrderLineService _salesOrderLineService;
		IWarehouseTotalService _warehouseTotalService;
		IServiceProvider _serviceProvider;

		public DispatchBySalesOrderLineLineListViewModel(IHttpClientService httpClientService, ISalesOrderLineService salesOrderLineService, IWarehouseTotalService warehouseTotalService, IServiceProvider serviceProvider)
		{
			_httpClientService = httpClientService;
			_salesOrderLineService = salesOrderLineService;
			_warehouseTotalService = warehouseTotalService;
			_serviceProvider = serviceProvider;

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
		Customer current;

		[ObservableProperty]
		Warehouse warehouse;

		[ObservableProperty]
		ShipInfo shipInfo;

		public ObservableCollection<WarehouseTotal> WarehouseTotalList { get; } = new();
		public ObservableCollection<WaitingOrderLineGroup> WaitingOrderLineGroupList { get; } = new();
		public ObservableCollection<WaitingOrderLineGroup> SelectedWaitingOrderLineGroupList { get; } = new();

		public ObservableCollection<WaitingOrderLineGroup> Result { get; } = new();
		public ObservableCollection<WaitingOrderLine> Lines { get; } = new();
        public ObservableCollection<WaitingOrderLine> ChangedLines { get; } = new();


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
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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

				await GetWarehouseTotalAsync(httpClient);
				await GetLinesFromFiche(httpClient);
				await SetGroupLinesByProduct();
				await FIFOCalculate();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
						Result.Clear();
						foreach (var item in WaitingOrderLineGroupList.ToList().Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText)))
						{
							Result.Add(item);
						}
					}
				}
				else
				{
					SearchText = string.Empty;
					Result.Clear();
					foreach (var item in WaitingOrderLineGroupList)
					{
						Result.Add(item);
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
					//switch (response)
					//{
					//	case "Termin Tarihi Büyükten Küçüğe":
					//		Result.Clear();
					//		foreach (var item in Items.OrderByDescending(x => x.DueDate).ToList())
					//		{
					//			Result.Add(item);
					//		}
					//		break;
					//	case "Termin Tarihi Küçükten Büyüğe":
					//		Result.Clear();
					//		foreach (var item in Items.OrderBy(x => x.DueDate).ToList())
					//		{
					//			Result.Add(item);
					//		}
					//		break;
					//	default:
					//		await ReloadAsync();
					//		break;

					//}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
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

		async Task GetWarehouseTotalAsync(HttpClient httpClient)
		{
			try
			{
				WarehouseTotalList.Clear();

				var warehouseNumber = Warehouse.Number;

				var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, (int)warehouseNumber, "1,2,3,4,10,11,12,13", SearchText, WarehouseTotalOrderBy.nameasc, 0, 10000);
				foreach (var item in result.Data)
				{
					WarehouseTotalList.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
					await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
				}
			});
		}
		async Task GetLinesFromFiche(HttpClient httpClient)
		{
			try
			{
				Lines.Clear();

				var result = await _salesOrderLineService.GetObjectsByCurrentIdAndWarehouseNumber(httpClient, Current.ReferenceId, Warehouse.Number, true, SearchText, OrderBy, CurrentPage, PageSize);
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					Lines.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
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
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
                DispatchBySalesOrderLineLineChangeBottomSheetViewModel viewModel = _serviceProvider.GetService<DispatchBySalesOrderLineLineChangeBottomSheetViewModel>();
                DispatchBySalesOrderLineLineChangeBottomSheetView sheet = new(viewModel);
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

        [RelayCommand]
        async Task GoToSummaryAsync()
        {
            if (IsBusy)
                return;
            try
            {
                foreach (var item in SelectedWaitingOrderLineGroupList.Where(x => x.IsSelected))
                {
                    foreach (var line in item.WaitingOrderLines.Where(x => x.TempQuantity > 0))
                    {
                        ChangedLines.Add(line);
                    }
                }
                if (ChangedLines.Any())
                {

                    await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineSummaryView)}", new Dictionary<string, object>
                    {
                        ["SelectedOrderLines"] = ChangedLines,
						[nameof(Warehouse)] = Warehouse,
						[nameof(Current)] = Current,
						[nameof(ShipInfo)] = ShipInfo
                    });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
            }
        }

    }
}
