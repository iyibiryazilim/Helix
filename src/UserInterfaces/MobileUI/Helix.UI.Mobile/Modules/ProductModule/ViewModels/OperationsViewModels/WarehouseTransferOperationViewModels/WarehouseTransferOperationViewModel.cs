using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class WarehouseTransferOperationViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseService _warehouseService;
	IWarehouseTotalService _warehouseTotalService;

	
	public ObservableCollection<WarehouseTotal> Items { get; } = new();
	public ObservableCollection<WarehouseTotal> SelectedItems { get; } = new();
	public Command GetDataCommand { get; }
	public Command<string> SearchCommand { get; }
	
	public WarehouseTransferOperationViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, IWarehouseTotalService warehouseTotalService)
	{
		Title = "Ambar Transfer İşlemleri";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
		_warehouseTotalService = warehouseTotalService;

		GetDataCommand  = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (text) => await PerformSearchAsync(text));
	}

	[ObservableProperty]
	Warehouse warehouse;
	[ObservableProperty]
	WarehouseTotalOrderBy warehouseTotalOrderBy = WarehouseTotalOrderBy.codeasc;
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20000;

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(ReloadAsync);
			
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

	[RelayCommand]
	async Task LoadMoreAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage++;
			var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, WarehouseTotalOrderBy, CurrentPage, PageSize);

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
			await Shell.Current.DisplayAlert("Veri yükleme hatası: ", $"{ex.Message}", "Tamam");
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
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, WarehouseTotalOrderBy, CurrentPage, PageSize);
			if(result.Data.Any())
			{
				Items.Clear();
				foreach (WarehouseTotal item in result.Data)
				{
					Items.Add(item);

				}
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
	private void ToggleSelection(WarehouseTotal item)
	{
		item.IsSelected = !item.IsSelected;
		if(item.IsSelected)
		{
			SelectedItems.Add(item);
		} else
		{
			SelectedItems.Remove(item);
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
	async Task SortAsync()
	{
		if (IsBusy)
			return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Kod A-Z", "Kod Z-A", "Miktara Göre Artan", "Miktara Göre Azalan");
			if(!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch(response)
				{
					case "Ad A-Z":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.nameasc;
						await ReloadAsync();
						break;
					case "Ad Z-A":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.namedesc;
						await ReloadAsync();
						break;
					case "Kod A-Z":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.codeasc;
						await ReloadAsync();
						break;
					case "Kod Z-A":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.codedesc;
						await ReloadAsync();
						break;
					case "Miktara Göre Artan":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.quantityasc;
						await ReloadAsync();
						break;
					case "Miktara Göre Azalan":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.quantitydesc;
						await ReloadAsync();
						break;
					default:
						await ReloadAsync();
						break;
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Sıralama Hatası", ex.Message, "Tamam");
		}
		finally {
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

			if (SelectedItems.Count == 0)

				await Shell.Current.GoToAsync("..");
			else
			{
				bool answer = await Shell.Current.DisplayAlert("Uyarı", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");
				if (answer)
				{
					await Shell.Current.GoToAsync("..");
					SelectedItems.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");

		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToWarehouseTransferOperationSelectedItemsListViewAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			if (SelectedItems.Count > 0)
			{
				await Shell.Current.GoToAsync($"{nameof(WarehouseTransferOperationSelectedItemsListView)}", new Dictionary<string, object>
				{
					[nameof(Warehouse)] = Warehouse,
					[nameof(WarehouseTotal)] = SelectedItems
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için ürün seçmeniz gerekmektedir", "Tamam");
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}
	}

}
