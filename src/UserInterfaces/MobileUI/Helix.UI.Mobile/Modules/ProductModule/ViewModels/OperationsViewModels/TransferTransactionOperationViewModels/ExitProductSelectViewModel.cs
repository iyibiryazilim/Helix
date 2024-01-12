using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels
{
	[QueryProperty(nameof(TransferTransactionModel), nameof(TransferTransactionModel))]
	public partial class ExitProductSelectViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;

		IWarehouseTotalService _warehouseTotalService;
		//Lists
		public ObservableCollection<WarehouseTotal> Items { get; } = new();
		public ObservableCollection<WarehouseTotal> Results { get; } = new();
		public ObservableCollection<WarehouseTotal> SelectedProducts { get; } = new();
		//Commands
		public Command SearchCommand { get; }
		public Command GetProductsCommand { get; }

		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.nameasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 100000;
		[ObservableProperty]
		string groupCode = string.Empty;

		[ObservableProperty]
		TransferTransactionModel transferTransactionModel;
		public ExitProductSelectViewModel(IHttpClientService httpClientService, IWarehouseTotalService warehouseTotalService)
		{

			Title = "Çıkış Ürün Listesi";
			_httpClientService = httpClientService;

			_warehouseTotalService = warehouseTotalService;
			GetProductsCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));


		}

		[RelayCommand]
		private void ToggleSelection(WarehouseTotal item)
		{
			item.IsSelected = !item.IsSelected;
			if (item.IsSelected)
			{
				SelectedProducts.Add(item);
			}
			else
			{
				SelectedProducts.Remove(item);
			}
		}
		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetProductsAsync);

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
		async Task GetProductsAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, TransferTransactionModel.ExitWarehouse.Number, "1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);
				foreach (WarehouseTotal item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
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
						foreach (var item in Items.ToList().Where(x => x.ProductName.Contains(SearchText) || x.ProductCode.ToString().Contains(SearchText)))
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

				var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, TransferTransactionModel.ExitWarehouse.Number, "1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);

				foreach (WarehouseTotal item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}


			}
			catch (Exception ex)
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

		[RelayCommand]
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Kod A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.ProductCode).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Kod Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.ProductCode).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.ProductName).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.ProductName).ToList())
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
		async Task GoToEntryWarehouseSelect()
		{
			if (!SelectedProducts.Any())
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Malzeme seçimi yapmanız gerekmektedir", "Tamam");
			}
			else
			{
				TransferTransactionModel.Products = [];
				foreach (var item in SelectedProducts)
				{
					TransferTransactionModel.Products.Add(new TransferTransactionProduct()
					{
						ExitProduct = new Product()
						{
							ReferenceId = item.ProductReferenceId,
							Code = item.ProductCode,
							Name = item.ProductName,
							UnitsetCode = item.UnitsetCode,
							UnitsetReferenceId = item.UnitsetReferenceId, 
							StockQuantity = item.OnHand
						}
					});
				}
				await Shell.Current.GoToAsync($"{nameof(ChangeProductView)}", new Dictionary<string, object>
				{
					[nameof(TransferTransactionModel)] = TransferTransactionModel
				});
			}
		}
	}
}
