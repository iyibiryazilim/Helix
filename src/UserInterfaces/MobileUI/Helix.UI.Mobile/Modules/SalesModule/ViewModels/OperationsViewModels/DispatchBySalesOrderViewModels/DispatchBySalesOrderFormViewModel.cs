using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

[QueryProperty(name: nameof(SelectedOrderLines), queryId: nameof(SelectedOrderLines))]
[QueryProperty(name: nameof(Current), queryId: nameof(Current))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ShipInfo), queryId: nameof(ShipInfo))]
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
    public bool isVisible = false;

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

    [ObservableProperty]
    string selectedTransactionType;

    [ObservableProperty]
    ShipInfo shipInfo;



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
            await Task.WhenAll(GetCarrierAsync(), GetDriverAsync());

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

    async Task RetailSalesDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");


            RetailSalesDispatchTransactionDto retailSalesDispatch = new RetailSalesDispatchTransactionDto();
            retailSalesDispatch.WarehouseNumber = Warehouse.Number;
            retailSalesDispatch.CarrierCode = SalesFormModel.SelectedCarrier.Code;
            retailSalesDispatch.DriverFirstName = SalesFormModel.SelectedDriver.Name;
            retailSalesDispatch.DriverLastName = SalesFormModel.SelectedDriver.Surname;
            retailSalesDispatch.IdentityNumber = SalesFormModel.SelectedDriver.IdentityNumber;
            retailSalesDispatch.Plaque = SalesFormModel.SelectedDriver.PlateNumber;
            retailSalesDispatch.TransactionDate = SalesFormModel.TransactionDate;
            retailSalesDispatch.TransactionType = 7;
            //retailSalesDispatch.ShipInfoReferenceId =0;
            //retailSalesDispatch.ShipInfoCode = "";
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            retailSalesDispatch.Description = SalesFormModel.Description;
            retailSalesDispatch.CurrentCode = Current.Code;
            retailSalesDispatch.CurrentReferenceId = Current.ReferenceId;
            retailSalesDispatch.EmployeeOid = employeeOid;



            foreach (var item in SelectedOrderLines)
            {
                RetailSalesDispatchTransactionLineDto retailSalesDispatchLine = new RetailSalesDispatchTransactionLineDto();

                retailSalesDispatchLine.ProductCode = item.ProductCode;
                retailSalesDispatchLine.ProductReferenceId = item.ProductReferenceId;
                retailSalesDispatchLine.CurrentCode = Current.Code;
                retailSalesDispatchLine.CurrentReferenceId = Current.ReferenceId;
                retailSalesDispatchLine.Quantity = item.Quantity;
                retailSalesDispatchLine.UnitsetCode = item.UnitsetCode;
                retailSalesDispatchLine.UnitsetReferenceId = item.UnitsetReferenceId;
                retailSalesDispatchLine.TransactionType = 7;
                retailSalesDispatchLine.SubUnitsetCode = item.SubUnitsetCode;
                retailSalesDispatchLine.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                retailSalesDispatchLine.OrderReferenceId = item.ReferenceId;
                retailSalesDispatchLine.WarehouseNumber = Warehouse.Number;
                retailSalesDispatch.Lines.Add(retailSalesDispatchLine);
            }

            var result =  await _retailSalesDispatchTransactionService.InsertObject(httpClient, retailSalesDispatch);
            if (result.IsSuccess)
            {
                var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                if (userResponse)
                {
                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 7,
                         ["SuccessMessage"] = "İrsaliye Başarıyla Gönderildi."
                    });
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
            }

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
    async Task WholeSalesDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");


            WholeSalesDispatchTransactionDto wholeSalesDispatchTransactionDto = new WholeSalesDispatchTransactionDto();
            wholeSalesDispatchTransactionDto.WarehouseNumber = Warehouse.Number;
            wholeSalesDispatchTransactionDto.CarrierCode = SalesFormModel.SelectedCarrier.Code;
            wholeSalesDispatchTransactionDto.DriverFirstName = SalesFormModel.SelectedDriver.Name;
            wholeSalesDispatchTransactionDto.DriverLastName = SalesFormModel.SelectedDriver.Surname;
            wholeSalesDispatchTransactionDto.IdentityNumber = SalesFormModel.SelectedDriver.IdentityNumber;
            wholeSalesDispatchTransactionDto.Plaque = SalesFormModel.SelectedDriver.PlateNumber;
            wholeSalesDispatchTransactionDto.TransactionDate = SalesFormModel.TransactionDate;
            wholeSalesDispatchTransactionDto.TransactionType = 8;
            wholeSalesDispatchTransactionDto.GroupType = 2;
            wholeSalesDispatchTransactionDto.IOType = 4;

            //retailSalesDispatch.ShipInfoReferenceId =0;
            //retailSalesDispatch.ShipInfoCode = "";
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            wholeSalesDispatchTransactionDto.Description = SalesFormModel.Description;
            wholeSalesDispatchTransactionDto.CurrentCode = Current.Code;
            wholeSalesDispatchTransactionDto.CurrentReferenceId = Current.ReferenceId;
            wholeSalesDispatchTransactionDto.EmployeeOid = employeeOid;



            foreach (var item in SelectedOrderLines)
            {
                WholeSalesDispatchTransactionLineDto wholeSalesDispatchTransactionLineDto = new WholeSalesDispatchTransactionLineDto();

                wholeSalesDispatchTransactionLineDto.ProductCode = item.ProductCode;
                wholeSalesDispatchTransactionLineDto.ProductReferenceId = item.ProductReferenceId;
                wholeSalesDispatchTransactionLineDto.CurrentCode = item.CurrentCode;
                wholeSalesDispatchTransactionLineDto.CurrentReferenceId = item.CurrentReferenceId;
                wholeSalesDispatchTransactionLineDto.Quantity = item.Quantity;
                wholeSalesDispatchTransactionLineDto.UnitsetCode = item.UnitsetCode;
                wholeSalesDispatchTransactionLineDto.UnitsetReferenceId = item.UnitsetReferenceId;
                wholeSalesDispatchTransactionLineDto.TransactionType = 8;
                wholeSalesDispatchTransactionLineDto.GroupType = 2;
                wholeSalesDispatchTransactionLineDto.IOType = 4;
                wholeSalesDispatchTransactionLineDto.SubUnitsetCode = item.SubUnitsetCode;
                wholeSalesDispatchTransactionLineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                wholeSalesDispatchTransactionLineDto.OrderReferenceId = item.ReferenceId;
                wholeSalesDispatchTransactionLineDto.WarehouseNumber = Warehouse.Number;
                wholeSalesDispatchTransactionDto.Lines.Add(wholeSalesDispatchTransactionLineDto);
            }

            var result = await _wholeSalesDispatchTransactionService.InsertObject(httpClient, wholeSalesDispatchTransactionDto);
            if (result.IsSuccess)
            {
                await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 7,
                    ["SuccessMessage"] = "İrsaliye Başarıyla Gönderildi."

                });
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
            }

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
    async Task InsertAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            if (SelectedTransactionType==null)
            {
                await Shell.Current.DisplayAlert("Uyarı", "İrsaliye Türünü Seçiniz", "Tamam");
            }

            switch (SelectedTransactionType)
            {

                case "Toptan Satış İrsaliyesi":
                    await WholeSalesDispatchInsert();
                    break;
                case "Perakende Satış İrsaliyesi":
                    await RetailSalesDispatchInsert();
                    break;

                default:
                    break;
            }
        }
        finally
        {
            IsBusy = false;
        }

    }



}
