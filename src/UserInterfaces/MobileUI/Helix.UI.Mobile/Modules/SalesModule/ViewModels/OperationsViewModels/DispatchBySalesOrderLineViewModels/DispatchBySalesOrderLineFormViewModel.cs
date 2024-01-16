using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels
{
    [QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

    public partial class DispatchBySalesOrderLineFormViewModel : BaseViewModel
	{

        IHttpClientService _httpClientService;
        IWarehouseService _warehouseService;
        ICustomerService _customerService;
        IDriverService _driverService;
        ICarrierService _carrierService;
        ISpeCodeService _speCodeService;

        public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
        public ObservableCollection<Customer> CustomerItems { get; } = new();
        public ObservableCollection<Driver> DriverItems { get; } = new();

        public ObservableCollection<Carrier> CarrierItems { get; } = new();
        public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();




        [ObservableProperty]
        ObservableCollection<ProductModel> productModel;
        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        ProductOrderBy orderBy = ProductOrderBy.nameasc;
        [ObservableProperty]
        int currentPage = 0;

        [ObservableProperty]
        SalesFormModel salesFormModel= new();
        [ObservableProperty]
        int pageSize = 20;
        [ObservableProperty]
        WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
        [ObservableProperty]
        CustomerOrderBy customerOrderBy = CustomerOrderBy.nameasc;

        [ObservableProperty]
        public string speCode = string.Empty;

        public DispatchBySalesOrderLineFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ICustomerService customerService, ICarrierService carrierService, IDriverService driverService, ISpeCodeService speCodeService)
        {
            Title = "Sevk";
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;
            _customerService = customerService;
            _carrierService = carrierService;
            _driverService = driverService;
            _speCodeService = speCodeService;


        }
        [RelayCommand]
        public async Task GetSpeCodeAsync()
        {

            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _speCodeService.GetObjects(httpClient);
                string action;
                if (result.Data.Any())
                {
                    SpeCodeModelItems.Clear();

                    foreach (var item in result.Data)
                    {
                        
                        SpeCodeModelItems.Add(item);
                    }
                    List<string> speCodeStrings = SpeCodeModelItems.Select(code => code.SpeCode).ToList();

                    action = await Shell.Current.DisplayActionSheet("Özel Kod:", "Vazgeç", null, speCodeStrings.ToArray());

                    SpeCode = action;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;

            }
        }

        [RelayCommand]
        public async Task GetDriverAsync()
        {

            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _driverService.GetObjects(httpClient);

                if (result.Data.Any())
                {
                    DriverItems.Clear();

                    foreach (var item in result.Data)
                    {
                        await Task.Delay(100);
                        DriverItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;

            }
        }

        [RelayCommand]
        public async Task GetCarrierAsync()
        {

            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _carrierService.GetObjects(httpClient);

                if (result.Data.Any())
                {
                    DriverItems.Clear();

                    foreach (var item in result.Data)
                    {
                        await Task.Delay(100);
                        CarrierItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;

            }
        }







        [RelayCommand]
        public async Task GetWarehouseAsync()
        {

            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _warehouseService.GetObjects(httpClient, SearchText, WarehouseOrderBy, CurrentPage, PageSize);

                if (result.Data.Any())
                {
                    WarehouseItems.Clear();

                    foreach (var item in result.Data)
                    {
                        await Task.Delay(100);
                        WarehouseItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;

            }
        }

        [RelayCommand]
        public async Task GetCustomerAsync()
        {
            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _customerService.GetObjects(httpClient, SearchText, CustomerOrderBy, CurrentPage, PageSize);

                if (result.Data.Any())
                {
                    CustomerItems.Clear();

                    foreach (var item in result.Data)
                    {
                        await Task.Delay(100);
                        CustomerItems.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error:", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
