using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels

{
	public partial class SalesPanelViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ICustomQueryService _customQueryService;

		public ObservableCollection<Customer> Customers { get; } = new();
		public ObservableCollection<CustomerTransactionLine> Lines { get; } = new();


		public SalesPanelViewModel(ICustomQueryService customQueryService, IHttpClientService httpClientService)
		{
			_customQueryService = customQueryService;
			_httpClientService = httpClientService;

			GetTopCustomersAsync();
			GetLastTransactionsAsync();

		}
		async Task GetTopCustomersAsync()
		{
			try
			{
				var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new CustomerQuery().GetTopCustomers());
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<Customer>(item);
					if (obj.Image == "{}")
					{
						obj.Image = null;
					}
					Customers.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}

		}

		async Task GetLastTransactionsAsync()
		{
			try
			{
				var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new CustomerQuery().GetLastSaleLines());
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<CustomerTransactionLine>(item);

					Lines.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}

		}
	}
}
