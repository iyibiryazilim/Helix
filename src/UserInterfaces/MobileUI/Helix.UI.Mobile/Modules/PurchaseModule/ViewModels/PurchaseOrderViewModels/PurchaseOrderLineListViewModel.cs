using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels
{
    public partial class PurchaseOrderLineLineListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IPurchaseOrderLineService _purchaseOrderLineService;
        public ObservableCollection<PurchaseOrderLine> Items { get; } = new();
        public Command GetTransactionCommand { get; }

        public PurchaseOrderLineLineListViewModel(IHttpClientService httpClientService, IPurchaseOrderLineService purchaseOrderLineService)
        {
            _httpClientService = httpClientService;
            _purchaseOrderLineService = purchaseOrderLineService;
            GetTransactionCommand = new Command(async () => await LoadData());
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await Task.WhenAll(
                  GetTransactionAsync()
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
        async Task GetTransactionAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                var result = await _purchaseOrderLineService.GetWaitingOrders(httpClient);
                foreach (PurchaseOrderLine item in result.Data)
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
