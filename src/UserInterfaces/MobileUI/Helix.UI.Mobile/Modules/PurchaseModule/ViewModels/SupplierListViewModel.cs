using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels
{
	public partial class SupplierListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ISupplierService _supplierService;
		public ObservableCollection<Supplier> Items { get; } = new();
		public Command GetSupplierCommand { get; }

		public SupplierListViewModel(IHttpClientService httpClientService, ISupplierService supplierService)
		{
			_httpClientService = httpClientService;
			_supplierService = supplierService;
			GetSupplierCommand = new Command(async () => await LoadData());
		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await Task.WhenAll(
				  GetSupplierAsync()
				);

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
		async Task GetSupplierAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _supplierService.GetObjects(httpClient);
				foreach (Supplier item in result.Data)
				{
					Items.Add(item);
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
