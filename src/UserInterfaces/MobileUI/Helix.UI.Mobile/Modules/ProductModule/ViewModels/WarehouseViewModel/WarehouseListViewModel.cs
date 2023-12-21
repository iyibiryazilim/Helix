using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
public partial class WarehouseListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly IWarehouseService _warehouseService;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseOrderBy orderBy = WarehouseOrderBy.numberasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;

	public ObservableCollection<Warehouse> Items { get; } = new();
	public Command GetWarehousesCommand { get; }
	public Command<string> PerformSearchCommand { get; }

	public WarehouseListViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
	{
		Title = "Ambarlar";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
		GetWarehousesCommand = new Command(async () => await LoadData());
		PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

	}
	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			//await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);
			await ReloadAsync();

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

	async Task GetWarehousesAsync()
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				foreach (Warehouse item in result.Data)
				{
					Items.Add(item);
				}
			}
		}

		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Warehouse Error:", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
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
			var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					await Task.Delay(50);
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
			var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy,CurrentPage, PageSize);

			if (result.Data.Any())
			{
				Items.Clear();

				foreach (var item in result.Data)
				{
					await Task.Delay(100);
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Numaraya Göre Artan", "Numara Göre Azalan");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Ad A-Z":
						OrderBy = WarehouseOrderBy.nameasc; 
						await ReloadAsync();
						break;
					case "Ad Z-A":
						OrderBy = WarehouseOrderBy.namedesc;
						await ReloadAsync();
						break;
					case "Numaraya Göre Artan":
						OrderBy = WarehouseOrderBy.numberasc;
						await ReloadAsync();
						break;
					case "Numaraya Göre Azalan":
						OrderBy = WarehouseOrderBy.numberdesc;
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
}
