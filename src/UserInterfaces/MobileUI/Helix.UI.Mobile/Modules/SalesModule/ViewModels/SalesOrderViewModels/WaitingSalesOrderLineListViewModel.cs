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

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.SalesOrderViewModels;

public partial class WaitingSalesOrderLineListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly ISalesOrderLineService _salesOrderLineService;

	public ObservableCollection<WaitingOrderLine> Items { get; } = new();
	public Command GetWaitingSalesOrderLinesCommand { get; }
	public Command PerformSearchCommand { get; }
	public WaitingSalesOrderLineListViewModel(IHttpClientService httpClientService,ISalesOrderLineService salesOrderLineService)
    {
		Title = "Bekleyen Satış Siparişleri";
        _httpClientService = httpClientService;
        _salesOrderLineService = salesOrderLineService;

		PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		GetWaitingSalesOrderLinesCommand = new Command(async () => await LoadData());
	}

	[ObservableProperty] 
	string searchText = string.Empty;
	[ObservableProperty]
	SalesOrdersLineOrderBy orderBy = SalesOrdersLineOrderBy.duedatedesc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	bool includeWaiting=true;
	[ObservableProperty]
	int pageSize = 20;


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
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
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
			var result = await _salesOrderLineService.GetObjects(httpClient, IncludeWaiting, SearchText, OrderBy, CurrentPage, PageSize);
			if(result.Data.Any())
			{
				Items.Clear();
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					await Task.Delay(100);
					Items.Add(obj);
				}
				
			}
		} catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Reload Error: ", $"{ex.Message}", "Tamam");
		}
		finally {
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

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage++;
			var result = await _salesOrderLineService.GetObjects(httpClient, IncludeWaiting, SearchText, OrderBy, CurrentPage, PageSize);
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarihe Göre Artan", "Tarihe Göre Azalan", "Ürün Adı A-Z", "Ürün Adı Z-A", "Ürün Kodu A-Z", "Ürün Kodu Z-A", "Müşteri Adı A-Z", "Müşteri Adı Z-A", "Müşteri Kodu A-Z", "Müşteri Kodu Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Tarihe Göre Artan":
						OrderBy = SalesOrdersLineOrderBy.duedateasc;
						await ReloadAsync();
						break;
					case "Tarihe Göre Azalan":
						OrderBy = SalesOrdersLineOrderBy.duedatedesc;
						await ReloadAsync();
						break;
					case "Ürün Adı A-Z":
						OrderBy = SalesOrdersLineOrderBy.productnameasc;
						await ReloadAsync();
						break;
					case "Ürün Adı Z-A":
						OrderBy = SalesOrdersLineOrderBy.productnamedesc;
						await ReloadAsync();
						break;
					case "Ürün Kodu A-Z":
						OrderBy = SalesOrdersLineOrderBy.productcodeasc;
						await ReloadAsync();
						break;
					case "Ürün Kodu Z-A":
						OrderBy = SalesOrdersLineOrderBy.productcodedesc;
						await ReloadAsync();
						break;
					case "Müşteri Adı A-Z":
						OrderBy = SalesOrdersLineOrderBy.customernameasc;
						await ReloadAsync();
						break;
					case "Müşteri Adı Z-A":
						OrderBy = SalesOrdersLineOrderBy.customernamedesc;
						await ReloadAsync();
						break;
					case "Müşteri Kodu A-Z":
						OrderBy = SalesOrdersLineOrderBy.customercodeasc;
						await ReloadAsync();
						break;
					case "Müşteri Kodu Z-A":
						OrderBy = SalesOrdersLineOrderBy.customercodedesc;
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

	async Task PerformSearchAsync(string text)
	{
		if (IsBusy)
			return;
		try
		{
			if(!string.IsNullOrEmpty(text))
			{
				if(text.Length >= 3)
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
}
