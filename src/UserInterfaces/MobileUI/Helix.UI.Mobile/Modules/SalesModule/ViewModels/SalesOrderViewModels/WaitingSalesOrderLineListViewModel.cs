using Helix.UI.Mobile.Helpers.HttpClientHelper;
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
	public Command GetWaitingSalesOrdersCommand { get; }
	public WaitingSalesOrderLineListViewModel(IHttpClientService httpClientService,ISalesOrderLineService salesOrderLineService)
    {
        _httpClientService = httpClientService;
        _salesOrderLineService = salesOrderLineService;
		GetWaitingSalesOrdersCommand = new Command(async () => await LoadData());
	}

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await Task.WhenAll(
			  GetWaitingSalesOrdersAsync()
			);

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
	async Task GetWaitingSalesOrdersAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			//var result = await _salesOrderLineService.GetObjects(httpClient,true);
			//foreach (SalesOrderLine item in result.Data)
			//{
			//	Items.Add(item);
			//}


		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
}
