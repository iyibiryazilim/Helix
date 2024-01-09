using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using Java.Nio.Channels;
using Kotlin.Properties;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

[QueryProperty(name: nameof(SelectedOrderLines), queryId: nameof(SelectedOrderLines))]
public partial class DispatchBySalesOrderFormViewModel:BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    ICustomerService _customerService;

	public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
    public ObservableCollection<Customer> CustomerItems { get; } = new();

    [ObservableProperty]
    ObservableCollection<WaitingOrderLine> selectedOrderLines;


    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 200000;
    [ObservableProperty]
    WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
    [ObservableProperty]
    CustomerOrderBy customerOrderBy = CustomerOrderBy.nameasc;

    [ObservableProperty]
    SalesFormModel salesFormFormModel = new();




    public DispatchBySalesOrderFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ICustomerService customerService)
    {
        Title = "Form";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _customerService = customerService;
       
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
