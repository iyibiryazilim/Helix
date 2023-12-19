using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel
{
    public partial class WarehouseListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IWarehouseService _warehouseService;
        public ObservableCollection<Warehouse> Items { get; } = new();
        public Command GetWarehousesCommand { get; }

        public WarehouseListViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
        {
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;
            GetWarehousesCommand= new Command(async () => await LoadData());
        }
        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task GetWarehousesAsync()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;
                IsRefreshing = true;
                var httpClient=_httpClientService.GetOrCreateHttpClient();
                var result = await _warehouseService.GetObjects(httpClient);
                if (Items.Any())
                {
                    Items.Clear();
                    foreach (Warehouse item in result.Data)
                    {
                        Items.Add(item);
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Warehouse Error:", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }




        }
       



    }
}
