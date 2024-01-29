using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
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
[QueryProperty(name: nameof(Current), queryId: nameof(Current))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]

public partial class DispatchBySalesOrderFormViewModel:BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    ICustomerService _customerService;
    IDriverService _driverService;
    ICarrierService _carrierService;
    ISpeCodeService _speCodeService;
    IRetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
    IWholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
    public ObservableCollection<Customer> CustomerItems { get; } = new();

    [ObservableProperty]
    ObservableCollection<WaitingOrderLine> selectedOrderLines;

    public ObservableCollection<Driver> DriverItems { get; } = new();

    public ObservableCollection<Carrier> CarrierItems { get; } = new();

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();



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
    public string speCode = string.Empty;

    [ObservableProperty]
    SalesFormModel salesFormModel = new();

    [ObservableProperty]
    Customer current;

    [ObservableProperty]
    Warehouse warehouse;




    public DispatchBySalesOrderFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ICustomerService customerService, IDriverService driverService, ICarrierService carrierService, ISpeCodeService speCodeService,IRetailSalesDispatchTransactionService retailSalesDispatchTransactionService,IWholeSalesDispatchTransactionService wholeSalesDispatchTransactionService)
    {
        Title = "Form";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _customerService = customerService;
        _driverService = driverService;
        _carrierService = carrierService;
        _speCodeService = speCodeService;
        _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
        _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
        GetDataCommand = new Command(async () => await LoadData());


    }
    public Command GetDataCommand { get; } 

    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            await Task.Delay(500);
            await Task.WhenAll(GetSpeCodeAsync(), GetCarrierAsync(), GetDriverAsync());

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

    [RelayCommand]
    public async Task GetSpeCodeAsync()
    {
        string action;

        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            CurrentPage = 0;
            var result = await _speCodeService.GetObjects(httpClient);

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
                CarrierItems.Clear();

                foreach (var item in result.Data)
                {
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
    async Task SalesDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            RetailSalesDispatchTransactionDto retailSalesDispatch = new RetailSalesDispatchTransactionDto();
            retailSalesDispatch.WarehouseNumber = Warehouse.Number;
            retailSalesDispatch.CarrierCode = SalesFormModel.SelectedCarrier.Code;
            retailSalesDispatch.DriverFirstName = SalesFormModel.SelectedDriver.Name;
            retailSalesDispatch.DriverLastName = SalesFormModel.SelectedDriver.Surname;
            retailSalesDispatch.IdentityNumber = SalesFormModel.SelectedDriver.IdentityNumber;
            retailSalesDispatch.Plaque = SalesFormModel.SelectedDriver.PlateNumber;
            retailSalesDispatch.TransactionDate = SalesFormModel.TransactionDate;
            //retailSalesDispatch.ShipInfoReferenceId =0;
            //retailSalesDispatch.ShipInfoCode = "";
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            retailSalesDispatch.Description = SalesFormModel.Description;
            retailSalesDispatch.CurrentCode = Current.Code;
            retailSalesDispatch.CurrentReferenceId = Current.ReferenceId;



            foreach (var item in SelectedOrderLines)
            {
                RetailSalesDispatchTransactionLineDto retailSalesDispatchLine = new RetailSalesDispatchTransactionLineDto();

                retailSalesDispatchLine.ProductCode = item.ProductCode;
                retailSalesDispatchLine.ProductReferenceId = item.ProductReferenceId;

                retailSalesDispatchLine.Quantity = item.Quantity;
                retailSalesDispatchLine.UnitsetCode = item.UnitsetCode;
                retailSalesDispatchLine.UnitsetReferenceId = item.UnitsetReferenceId;

                retailSalesDispatchLine.SubUnitsetCode = item.SubUnitsetCode;
                retailSalesDispatchLine.SubUnitsetReferenceId = item.SubUnitsetReferenceId;

                retailSalesDispatchLine.OrderReferenceId = item.ReferenceId;
                retailSalesDispatchLine.WarehouseNumber = Warehouse.Number;
                retailSalesDispatch.Lines.Add(retailSalesDispatchLine);
            }

            var result =  await _retailSalesDispatchTransactionService.InsertObject(httpClient, retailSalesDispatch);
            Console.WriteLine(result.Message);
           // return result;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Hata", ex.Message.ToString(), "Tamam");
            //return ex.ToString();
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
