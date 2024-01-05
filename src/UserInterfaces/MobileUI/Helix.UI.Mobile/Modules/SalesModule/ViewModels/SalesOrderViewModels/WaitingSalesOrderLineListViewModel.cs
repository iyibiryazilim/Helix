using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
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

	public ObservableCollection<SalesOrderLine> Items { get; } = new();
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

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _salesOrderLineService.GetObjects(httpClient, IncludeWaiting, SearchText, OrderBy, CurrentPage, PageSize);
			if(result.Data.Any())
			{
				Items.Clear();
				foreach (var item in result.Data)
				{
					await Task.Delay(100);
					Items.Add(item);
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
