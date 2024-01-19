using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.FastProductionModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
public partial class FastProductionSelectProductListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseTotalService _warehouseTotalService;
	IServiceProvider _serviceProvider;

	[ObservableProperty]
	Warehouse selectedWarehouse;

	public FastProductionSelectProductListViewModel(IHttpClientService httpClientService, IWarehouseTotalService warehouseTotalService, IServiceProvider serviceProvider)
	{
		Title = "Ürün Listesi";
		_httpClientService = httpClientService;
		_warehouseTotalService = warehouseTotalService;
		_serviceProvider = serviceProvider;

		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		GetItemsCommand = new Command(async () => await LoadData());
	}

	#region Commands
	public Command GetItemsCommand { get; }
	public Command<string> SearchCommand { get; }
	#endregion

	#region Lists
	public ObservableCollection<WarehouseTotal> Items { get; } = new();
	public ObservableCollection<WarehouseTotal> Results { get; } = new();
	#endregion

	#region Property
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 9000;

	[ObservableProperty]
	WarehouseTotal selectedProduct;
	#endregion

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetWarehouseTotalListAsync);
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

	async Task GetWarehouseTotalListAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _warehouseTotalService.GetWarehouseTotals(httpClient: httpClient, number: SelectedWarehouse.Number, cardType: "1,2,3,4,10,11,12,13", search: SearchText, orderBy: OrderBy, page: CurrentPage, pageSize: PageSize);

			if (result.Data.Any())
			{
				Items.Clear();
				Results.Clear();

				foreach (var item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
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

	async Task PerformSearchAsync(string text)
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
					foreach (var item in Items.ToList().Where(x => x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
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
	public async Task SortAsync()
	{
		if (IsBusy) return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Miktara Göre Artan", "Miktara Göre Azalan", "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A", "Ambar Numarasına Göre Artan", "Ambar Numarasına Göre Azalan", "Ambar Adı A-Z", "Ambar Adı Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Miktara Göre Artan":
						OrderBy = WarehouseTotalOrderBy.quantityasc;
						await GetWarehouseTotalListAsync();
						break;
					case "Miktara Göre Azalan":
						OrderBy = WarehouseTotalOrderBy.quantitydesc;
						await GetWarehouseTotalListAsync();
						break;
					case "Numara A-Z":
						OrderBy = WarehouseTotalOrderBy.warehousenumberasc;
						await GetWarehouseTotalListAsync();
						break;
					case "Numara Z-A":
						OrderBy = WarehouseTotalOrderBy.warehousenamedesc;
						await GetWarehouseTotalListAsync();
						break;
					case "Ad A-Z":
						OrderBy = WarehouseTotalOrderBy.nameasc;
						await GetWarehouseTotalListAsync();
						break;
					case "Ad Z-A":
						OrderBy = WarehouseTotalOrderBy.namedesc;
						await GetWarehouseTotalListAsync();
						break;
					default:
						await GetWarehouseTotalListAsync();
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
	private void ToggleSelection(WarehouseTotal item)
	{
		if (item == SelectedProduct)
		{
			SelectedProduct.IsSelected = false;
			SelectedProduct = null;
		}
		else
		{
			if (SelectedProduct != null)
			{
				SelectedProduct.IsSelected = false;
			}

			SelectedProduct = item;
			SelectedProduct.IsSelected = true;
		}
	}

	[RelayCommand]
	public async Task GoToNextAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			var fastProductionViewModel = _serviceProvider.GetService<FastProductionViewModel>();

			var model = new FastProductionCard
			{
				ProductReferenceId = SelectedProduct.ProductReferenceId,
				ProductCode = SelectedProduct.ProductCode,
				ProductName = SelectedProduct.ProductName,
				SubUnitsetCode = SelectedProduct.SubUnitsetCode,
				OnHand = SelectedProduct.OnHand,
				WarehouseReferenceId = SelectedWarehouse.ReferenceId,
				WarehouseName = SelectedWarehouse.Name,
				WarehouseNumber = SelectedWarehouse.Number,
				LastTransactionDate = SelectedWarehouse.LastTransactionDate
			};
			SelectedProduct.IsSelected = false;
			if (!fastProductionViewModel.FastProductionList.ToList().Exists(x => x.ProductCode == SelectedProduct.ProductCode))
			{
				fastProductionViewModel.FastProductionList.Add(model);
			} else
			{
				fastProductionViewModel.FastProductionList.ToList().First(x => x.ProductCode == SelectedProduct.ProductCode).OnHand += 1;
			}


			await Task.Delay(200);
			await Shell.Current.GoToAsync("../..");

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
}
