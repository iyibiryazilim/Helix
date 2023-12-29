using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel
{
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(CardType), nameof(CardType))]

	public partial class WarehouseDetailProductListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		IWarehouseTotalService _warehouseTotalService;
        public WarehouseDetailProductListViewModel(IHttpClientService httpClientService,IWarehouseTotalService warehouseTotalService)
        {
            _httpClientService = httpClientService;
            _warehouseTotalService = warehouseTotalService;
			GetProductsCommand = new Command(async () => await LoadData());
			PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
			Title = "Ambar Toplamları";
		}

		[ObservableProperty]
		Warehouse warehouse;

		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.codeasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;
		[ObservableProperty]
		int cardType;

		public ObservableCollection<WarehouseTotal> Items { get; } = new();
		public Command GetProductsCommand { get; }
		public Command<string> PerformSearchCommand { get; }

		
		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(ReloadAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		async Task PerformSearchAsync(string text)
		{
			if (IsBusy) return;

			try
			{
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Length >= 3)
					{
						SearchText = text;
						await ReloadAsync();
					}
				}
				else
				{
					SearchText = string.Empty;
					await ReloadAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Search Error:", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task LoadMoreAsync()
		{
			if (IsBusy) return;
			try
			{
				IsBusy = true;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				CurrentPage++;
				DataResult<IEnumerable<WarehouseTotal>> result = new();
				if (CardType != null)
				{
					result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, CardType.ToString(), SearchText, OrderBy, CurrentPage, PageSize);
				}
				else
				{
					result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);
				}
				if (result.Data.Any())
				{
					foreach (var item in result.Data)
					{
						await Task.Delay(100);
						Items.Add(item);
					}
				}
				else
				{
					CurrentPage--;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		async Task ReloadAsync()
		{
			if (IsBusy) return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				CurrentPage = 0;
				DataResult<IEnumerable<WarehouseTotal>> result = new();
				if (CardType!=0)
				{
					result = await _warehouseTotalService.GetWarehouseTotals(httpClient,Warehouse.Number,CardType.ToString(), SearchText, OrderBy, CurrentPage, PageSize);

				}
				else
				{
					
					
					result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);

				}

				if (result.Data.Any())
				{
					Items.Clear();

					foreach (var item in result.Data)
					{
						await Task.Delay(150);
						Items.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Reload Error:", $"{ex.Message}", "Tamam");
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
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Code A-Z", "Code Z-A","Miktara Göre Artan","Miktara Göre Azalan");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Ad A-Z":
							OrderBy = WarehouseTotalOrderBy.nameasc;
							await ReloadAsync();
							break;
						case "Ad Z-A":
							OrderBy = WarehouseTotalOrderBy.namedesc;
							await ReloadAsync();
							break;
						case "Code A-Z":
							OrderBy = WarehouseTotalOrderBy.codedesc;
							await ReloadAsync();
							break;
						case "Code Z-A":
							OrderBy = WarehouseTotalOrderBy.codedesc;
							await ReloadAsync();
							break;
						case "Miktara Göre Artan":
							OrderBy = WarehouseTotalOrderBy.quantityasc;
							await ReloadAsync();
							break;
						case "Miktara Göre Azalan":
							OrderBy = WarehouseTotalOrderBy.quantitydesc;
							await ReloadAsync();
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
				await Shell.Current.DisplayAlert("Sort Warehouse Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		public async Task GoToBackAsync()
		{
			try
			{
				IsBusy = true;

				await Shell.Current.GoToAsync("..");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}


	}
}
