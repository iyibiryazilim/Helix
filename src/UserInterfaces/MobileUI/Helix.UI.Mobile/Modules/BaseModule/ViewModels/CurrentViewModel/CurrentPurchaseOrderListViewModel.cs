using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

[QueryProperty(name: nameof(Current), queryId: nameof(Current))]
public partial class CurrentPurchaseOrderListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IPurchaseOrderLineService _purchaseOrderLineService;

	[ObservableProperty]
	Customer current;


	public ObservableCollection<WaitingOrderLine> Items { get; } = new();
	public Command PerformSearchCommand { get; }
	public Command GetItemsCommand { get; }

	public CurrentPurchaseOrderListViewModel(IHttpClientService httpClientService, IPurchaseOrderLineService purchaseOrderLineService)
	{
		Title = "Satınalma Siparişleri";
		_httpClientService = httpClientService;
		_purchaseOrderLineService = purchaseOrderLineService;

		PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		GetItemsCommand = new Command(async () => await LoadData());
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	PurchaseOrderLineOrderBy orderBy = PurchaseOrderLineOrderBy.datedesc;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	int currentPage = 0;


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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _purchaseOrderLineService.GetWaitingOrdersByCurrentId(httpClient, SearchText, OrderBy, Current.ReferenceId, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					await Task.Delay(100);
					Items.Add(obj);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Reload Error: ", $"{ex.Message}", "Tamam");
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

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage++;
			var result = await _purchaseOrderLineService.GetWaitingOrdersByCurrentId(httpClient, SearchText, OrderBy, Current.ReferenceId, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					await Task.Delay(100);
					Items.Add(obj);
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A", "Tarih A-Z", "Tarih Z-A");

			CurrentPage = 0;
			await Task.Delay(100);
			switch (response)
			{
				case "Kod A-Z":
					OrderBy = PurchaseOrderLineOrderBy.productcodeasc;
					await ReloadAsync();
					break;
				case "Kod Z-A":
					OrderBy = PurchaseOrderLineOrderBy.productcodedesc;
					await ReloadAsync();
					break;
				case "Ad A-Z":
					OrderBy = PurchaseOrderLineOrderBy.productnameasc;
					await ReloadAsync();
					break;
				case "Ad Z-A":
					OrderBy = PurchaseOrderLineOrderBy.productnamedesc;
					await ReloadAsync();
					break;
				case "Tarih A-Z":
					OrderBy = PurchaseOrderLineOrderBy.dateasc;
					await ReloadAsync();
					break;
				case "Tarih Z-A":
                    OrderBy = PurchaseOrderLineOrderBy.datedesc;
					await ReloadAsync();
					break;
				default:
					await ReloadAsync();
					break;
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
			await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToBackAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync("..");
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
