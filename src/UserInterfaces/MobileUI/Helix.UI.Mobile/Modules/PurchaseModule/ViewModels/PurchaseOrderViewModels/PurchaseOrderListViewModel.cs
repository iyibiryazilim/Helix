using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels
{
    public partial class PurchaseOrderListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public ObservableCollection<PurchaseOrder> Items { get; } = new();
        public Command GetSupplierCommand { get; }

        public PurchaseOrderListViewModel(IHttpClientService httpClientService, IPurchaseOrderService purchaseOrderService)
        {
            _httpClientService = httpClientService;
            _purchaseOrderService = purchaseOrderService;
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

                var result = await _purchaseOrderService.GetObjects(httpClient);
                foreach (PurchaseOrder item in result.Data)
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
