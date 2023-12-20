using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels
{
    public partial class PurchaseDispatchTransactionLineLineListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IPurchaseDispatchTransactionLineService _purchaseDispatchTransactionLineService;
        public ObservableCollection<PurchaseDispatchTransactionLine> Items { get; } = new();
        public Command GetLineCommand { get; }

        public PurchaseDispatchTransactionLineLineListViewModel(IHttpClientService httpClientService, IPurchaseDispatchTransactionLineService purchaseDispatchTransactionLineService)
        {
            _httpClientService = httpClientService;
            _purchaseDispatchTransactionLineService = purchaseDispatchTransactionLineService;
            GetLineCommand = new Command(async () => await LoadData());
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await Task.WhenAll(
                  GetLineAsync()
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
        async Task GetLineAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                var result = await _purchaseDispatchTransactionLineService.GetObjects(httpClient);
                foreach (PurchaseDispatchTransactionLine item in result.Data)
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
