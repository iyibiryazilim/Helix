using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
public partial class WarehouseCountingListViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	IWarehouseTotalService _warehouseTotalService;

	public WarehouseCountingListViewModel(IHttpClientService httpClient, IWarehouseTotalService warehouseTotalService)
	{
		Title = "Ambar Sayımı";
		_httpClient = httpClient;
		_warehouseTotalService = warehouseTotalService;

		GetItemsCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

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
	Warehouse selectedWarehouse;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 9000;
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
		catch(Exception ex)
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

			var httpClient = _httpClient.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _warehouseTotalService.GetWarehouseTotals(httpClient: httpClient, number: SelectedWarehouse.Number, cardType: "1,2,3,4,10,11,12,13", search: SearchText, orderBy: OrderBy, page:CurrentPage, pageSize: PageSize);

			if(result.Data.Any())
			{
				Items.Clear();
				Results.Clear();

				foreach(var item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}
			}

		}
		catch(Exception ex)
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
	async Task RemoveItemAsync(WarehouseTotal item)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			//IsRefreshing = true;

			bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.ProductName} adlı ürün çıkartılacaktır. Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
			if (answer)
			{
				item.IsSelected = false;
				Items.Remove(item);
				Results.Remove(item);
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Ürün Silme Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task IncrementQuantityAsync(WarehouseTotal item)
	{
		//if (IsBusy)
		//	return;
		try
		{
			IsBusy = true;
			//IsRefreshing = true;

			item.QuantityCounter++;
			item.TempOnhand++;
			//item.OnHand++;

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Miktar Artırma Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task DecrementQuantityAsync(WarehouseTotal item)
	{
		//if (IsBusy)
		//	return;
		try
		{
			IsBusy = true;
			//IsRefreshing = true;


			if (item.QuantityCounter > 0)
			{
				item.QuantityCounter--;
				item.TempOnhand--;
				//item.OnHand--;

			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Miktar Azaltma Hatası", ex.Message, "Tamam");
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
		catch(Exception ex)
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
	async Task GoToWarehouseCountingSelectProductsViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			
			await Shell.Current.GoToAsync($"{nameof(WarehouseCountingSelectProductsView)}");
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
	async Task GoToNextAsync()
	{
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(WarehouseCountingSummaryView)}", new Dictionary<string, object>
			{
				[nameof(SelectedWarehouse)] = SelectedWarehouse,
				["Results"] = Results
			});
		}
		catch(Exception ex)
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
