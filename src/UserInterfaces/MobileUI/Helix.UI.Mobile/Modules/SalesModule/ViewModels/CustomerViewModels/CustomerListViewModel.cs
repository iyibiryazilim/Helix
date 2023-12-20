using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	public partial class CustomerListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ICustomerService _customerService;
		public ObservableCollection<Current> Items { get; } = new();
		public Command GetCustomersCommand { get; }
		public CustomerListViewModel(IHttpClientService httpClientService, ICustomerService customerService)
		{
			_httpClientService = httpClientService;
			_customerService = customerService;
			GetCustomersCommand = new Command(async () => await LoadData());
		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetCustomersAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
		async Task GetCustomersAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _customerService.GetObjects(httpClient,"",CustomerOrderBy.nameasc,0,20);

				if (result.Data.Any())
				{
					Items.Clear();
					foreach (Customer item in result.Data)
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



	}
}
