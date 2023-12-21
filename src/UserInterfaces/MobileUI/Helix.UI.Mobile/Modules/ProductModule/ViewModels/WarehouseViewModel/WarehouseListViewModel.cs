using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
public partial class WarehouseListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly IWarehouseService _warehouseService;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 20;
	[ObservableProperty]
	int pageSize = 0;

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
			await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);

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
			var result = await _warehouseService.GetObjects(httpClient);
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
			IsBusy = true;

			if(!string.IsNullOrEmpty(text))
			{
				if(text.Length >= 3)
				{
					SearchText = text;
					await ReloadAsync();
				}
			}
		} 
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Search Error:", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	async Task ReloadAsync()
	{
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _warehouseService.GetObjects(httpClient);

			if(result.Data.Any())
			{
				Items.Clear();

				foreach(var item in result.Data)
				{
					await Task.Delay(100);
					Items.Add(item);
				}
			}
		} catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Reload Error:", $"{ex.Message}", "Tamam");
		} finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
}
