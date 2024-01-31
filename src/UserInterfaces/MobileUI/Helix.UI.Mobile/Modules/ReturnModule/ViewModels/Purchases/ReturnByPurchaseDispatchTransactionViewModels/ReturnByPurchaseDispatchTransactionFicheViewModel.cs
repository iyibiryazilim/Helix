using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(ShipInfo), nameof(ShipInfo))]

	public partial class ReturnByPurchaseDispatchTransactionFicheViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ISupplierTransactionService _supplierTransactionService;

		public ObservableCollection<DispatchTransaction> Items { get; } = new();
		public ObservableCollection<DispatchTransaction> Results { get; } = new();
		public ObservableCollection<DispatchTransaction> SelectedTransactions { get; } = new();


		public Command GetOrdersCommand { get; }
		public Command SearchCommand { get; }
		public Command SelectAllCommand { get; }


		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		SupplierTransactionOrderBy orderBy = SupplierTransactionOrderBy.datedesc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20000;

		[ObservableProperty]
		Supplier current;

		[ObservableProperty]
		Warehouse warehouse;

		[ObservableProperty]
		ShipInfo shipInfo;

		public ReturnByPurchaseDispatchTransactionFicheViewModel(IHttpClientService httpClientService, ISupplierTransactionService supplierTransactionService)
		{
			_httpClientService = httpClientService;
			_supplierTransactionService = supplierTransactionService;
			GetOrdersCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
			SelectAllCommand = new Command<bool>(async (isSelected) => await SelectAllAsync(isSelected));
			Title = "Satınalma İrsaliyeleri";
		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetTransactionsAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			} 
		}
		[RelayCommand]
		async Task GetTransactionsAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();

				if (ShipInfo != null)
				{
					var result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, Warehouse.Number, ShipInfo.ReferenceId, "1", CurrentPage, PageSize);
					Items.Clear();
					Results.Clear();
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<DispatchTransaction>(item);
						Items.Add(obj);
						Results.Add(obj);
					}
				}
				else
				{
					var result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, Warehouse.Number, "1", CurrentPage, PageSize);
					Items.Clear();
					Results.Clear();
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<DispatchTransaction>(item);
						Items.Add(obj);
						Results.Add(obj);
					}
				}



			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				IsBusy = false;
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
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
						IsBusy = true;
						SearchText = text;
						Results.Clear();
						foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText) || x.CurrentName.Contains(SearchText) || x.CurrentCode.Contains(SearchText)))
						{
							Results.Add(item);
						}
					}
				}
				else
				{
					IsBusy = true; 
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
				IsBusy = false;
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
				IsBusy = true;
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarih Büyükten Küçüğe", "Tarih Küçükten Büyüğe");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Tarih Büyükten Küçüğe":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.TransactionDate).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Tarih Küçükten Büyüğe":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.TransactionDate).ToList())
							{
								Results.Add(item);
							}
							break;
						default:
 							break;

					}
				}
			}
			catch (Exception ex)
			{
				IsBusy = false;
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
 			}
		}

		[RelayCommand]
		public async Task SelectAsync(DispatchTransaction model)
		{
			await Task.Run(async() =>
			{
				try
				{
					IsBusy = true;
					DispatchTransaction selectedItem = Results.FirstOrDefault(x => x.ReferenceId == model.ReferenceId);
					if (selectedItem != null)
					{
						if (selectedItem.IsSelected)
						{
							selectedItem.IsSelected = false;
							SelectedTransactions.Remove(selectedItem);

						}
						else
						{
							selectedItem.IsSelected = true;

							SelectedTransactions.Add(selectedItem);
						}
					}
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
					IsBusy = false;
					throw;
				}
				finally
				{
					IsBusy = false;
				}

			});
		}

		[RelayCommand]
		async Task GoToLineListAsync()
		{
			if (SelectedTransactions.Count > 0)
			{
				await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionLineListView)}", new Dictionary<string, object>
				{
					[nameof(SelectedTransactions)] = SelectedTransactions,
					[nameof(Warehouse)] = Warehouse,
					[nameof(ShipInfo)] = ShipInfo,
					[nameof(Current)] = Current
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
			}

		}

		public async Task SelectAllAsync(bool isSelected)
		{
			if (IsBusy)
				return;
			try
			{
				if (isSelected)
				{
					foreach (var item in Results)
					{
						item.IsSelected = true;
						SelectedTransactions.Add(item);
					}
				}
				else
				{
					foreach (var item in Results)
					{
						item.IsSelected = false;
						SelectedTransactions.Remove(item);
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
				IsBusy = false;
				throw;
			}
			finally
			{
				IsBusy = false;
			}
		}

	}
}
