using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class WarehouseDetailOutputTransactionViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	IWarehouseTransactionService _warehouseTransactionService;

	public WarehouseDetailOutputTransactionViewModel(IHttpClientService httpClient, IWarehouseTransactionService warehouseTransactionService)
	{
		Title = "Çıkış Hareketleri Listesi";
		_httpClient = httpClient;
		_warehouseTransactionService = warehouseTransactionService;

		PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		GetWarehouseDetailOutputTransactionsCommand = new Command(async () => await LoadData());
	}

	[ObservableProperty]
	Warehouse warehouse;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTransactionOrderBy orderBy = WarehouseTransactionOrderBy.DateDesc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;

	public ObservableCollection<WarehouseTransaction> Items { get; } = new();

	public Command PerformSearchCommand { get; }
	public Command GetWarehouseDetailOutputTransactionsCommand { get; }


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
			await Shell.Current.DisplayAlert("Warehouse Transaction Input Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task SortAsync()
	{
		if (IsBusy)
			return;

		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarihe Göre Azalan", "Tarihe Göre Artan", "Miktara Göre Azalan", "Miktara Göre Artan");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Tarihe Göre Azalan":
						OrderBy = WarehouseTransactionOrderBy.DateDesc;
						await ReloadAsync();
						break;
					case "Tarihe Göre Artan":
						OrderBy = WarehouseTransactionOrderBy.DateAsc;
						await ReloadAsync();
						break;
					case "Miktara Göre Azalan":
						OrderBy = WarehouseTransactionOrderBy.QuantityDesc;
						await ReloadAsync();
						break;
					case "Miktara Göre Artan":
						OrderBy = WarehouseTransactionOrderBy.QuantityAsc;
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
			await Shell.Current.DisplayAlert("Sort Error: ", $"{ex.Message}", "Tamam");
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

			var httpClient = _httpClient.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(httpClient, Warehouse.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

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
	async Task LoadMoreAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			CurrentPage++;
			var result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(httpClient, Warehouse.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
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
			await Shell.Current.DisplayAlert("Load More Error:", $"{ex.Message}", "Tamam");

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
	async Task GoToBackAsync()
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
