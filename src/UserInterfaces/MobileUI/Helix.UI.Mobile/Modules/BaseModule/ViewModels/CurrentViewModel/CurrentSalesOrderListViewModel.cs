using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

[QueryProperty(name: nameof(Current), queryId: nameof(Current))]
public partial class CurrentSalesOrderListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	ISalesOrderLineService _salesOrderLineService;

	[ObservableProperty]
	Customer current;

	public ObservableCollection<WaitingOrderLine> Items { get; } = new();

	public Command GetItemsCommand { get; }
	public Command PerformSearchCommand { get; }

	public CurrentSalesOrderListViewModel(IHttpClientService httpClientService, ISalesOrderLineService salesOrderLineService)
	{
		Title = "Satış Siparişleri";
		_httpClientService = httpClientService;
		_salesOrderLineService = salesOrderLineService;

		PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		GetItemsCommand = new Command(async () => await LoadData());
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	SalesOrdersLineOrderBy orderBy = SalesOrdersLineOrderBy.duedatedesc;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	bool includeWaiting = true;

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
			var result = await _salesOrderLineService.GetObjectsByCurrentId(httpClient, Current.ReferenceId, IncludeWaiting, SearchText, OrderBy, CurrentPage, PageSize);

			if(result.Data.Any())
			{
				Items.Clear();
				foreach(var item in result.Data)
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
			var result = await _salesOrderLineService.GetObjectsByCurrentId(httpClient, Current.ReferenceId, IncludeWaiting, SearchText, OrderBy, CurrentPage, PageSize);
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
			await Shell.Current.DisplayAlert("Load More Error: ", $"{ex.Message}", "Tamam");
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
		if (IsBusy)
			return;

		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A", "Tarih A-Z", "Tarih Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Kod A-Z":
						OrderBy = SalesOrdersLineOrderBy.productcodeasc;
						await ReloadAsync();
						break;
					case "Kod Z-A":
						OrderBy = SalesOrdersLineOrderBy.productcodedesc;
						await ReloadAsync();
						break;
					case "Ad A-Z":
						OrderBy = SalesOrdersLineOrderBy.productnameasc;
						await ReloadAsync();
						break;
					case "Ad Z-A":
						OrderBy = SalesOrdersLineOrderBy.productnamedesc;
						await ReloadAsync();
						break;
					case "Tarih A-Z":
						OrderBy = SalesOrdersLineOrderBy.duedatedesc;
						await ReloadAsync();
						break;
					case "Tarih Z-A":
						OrderBy = SalesOrdersLineOrderBy.duedateasc;
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
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
					await LoadData();
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
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
