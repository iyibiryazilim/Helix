using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(ShipInfo), nameof(ShipInfo))]
	public partial class ReturnByPurchaseDispatchTransactionLineWarehouseListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly IWarehouseService _warehouseService;
		ICustomQueryService _customQueryService;
		//Lists
		public ObservableCollection<Warehouse> Items { get; } = new();
		public ObservableCollection<Warehouse> Results { get; } = new();


		//Commands
		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }

		//Properties
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

		[ObservableProperty]
		Supplier current;

		[ObservableProperty]
		ShipInfo shipInfo;


		public ReturnByPurchaseDispatchTransactionLineWarehouseListViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ICustomQueryService customQueryService)
		{
			Title = "Ambar Listesi";
			_httpClientService = httpClientService;
			_warehouseService = warehouseService;
			_customQueryService = customQueryService;
			GetDataCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);

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
		async Task GetWarehousesAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.IsSuccess)
				{
					Items.Clear();
					Results.Clear();
					foreach (Warehouse item in result.Data)
					{
						Items.Add(item);
						Results.Add(item);
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
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
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
						SearchText = text.ToLower();
						Results.Clear();
						foreach (var item in Items.ToList().Where(x => x.Name.ToLower().Contains(SearchText) || x.LastTransactionDate.ToString().Contains(SearchText)))
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
				await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
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
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Numara A-Z", "Numara Z-A", "Ad A-Z", "Ad Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Numara A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Number).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Numara Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Number).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Name).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Name).ToList())
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
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		async Task GoToTransaction()
		{
			try
			{
				if (SelectedWarehouse == null)
				{
					await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Ambar seçimi yapmanız gerekmektedir", "Tamam");
				}
				else
				{
					await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionLineLineListView)}", new Dictionary<string, object>
					{
						[nameof(Warehouse)] = SelectedWarehouse,
						[nameof(Current)] = Current,
						[nameof(ShipInfo)] = ShipInfo
					});
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		private void ToggleSelection(Warehouse item)
		{
			if (item == SelectedWarehouse)
			{
				SelectedWarehouse.IsSelected = false;
				SelectedWarehouse = null;
			}
			else
			{
				if (SelectedWarehouse != null)
				{
					SelectedWarehouse.IsSelected = false;
				}
				SelectedWarehouse = item;
				SelectedWarehouse.IsSelected = true;
			}
		}
	}
}
