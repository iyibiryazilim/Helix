using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class SalesDispatchFormViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	//warehouseService
	IWarehouseService _warehouseService;
    ICustomerService _customerService;
    IServiceProvider _serviceProvider;
    IDriverService _driverService;
    ICarrierService _carrierService;
    ISpeCodeService _speCodeService;
    IShipInfoService _shipInfoService;
    IWholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
    IRetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
 

    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
    public ObservableCollection<Customer> CustomerItems { get; } = new();

    public ObservableCollection<Driver> DriverItems { get; } = new();

    public ObservableCollection<Carrier> CarrierItems { get; } = new();

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

    public ObservableCollection<ShipInfo> ShipInfoItems { get; } = new();




    [ObservableProperty]
    SalesFormModel salesFormModel = new();

    [ObservableProperty]
	ObservableCollection<ProductModel> productModel;
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    ProductOrderBy orderBy = ProductOrderBy.nameasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 20;
    [ObservableProperty]
    WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
    [ObservableProperty]
    CustomerOrderBy customerOrderBy = CustomerOrderBy.nameasc;
    [ObservableProperty]
    public int viewType;

    [ObservableProperty]
    public bool isVisible = true;

    [ObservableProperty]
    public bool isNotVisible = false;

    [ObservableProperty]
    Warehouse warehouse;
    [ObservableProperty]
    string selectedTransactionType;


    private Customer selectedCustomer;

    public Customer SelectedCustomer
    {
        get => selectedCustomer;
        set
        {
            SetProperty(ref selectedCustomer, value);
            Task.Run(async () => await GetShipInfoAsync(value));
        }
    }


    [ObservableProperty]
    public string speCode = string.Empty;
    public SalesDispatchFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ICustomerService customerService, IDriverService driverService,ICarrierService carrierService, ISpeCodeService speCodeService,IShipInfoService shipInfoService,IWholeSalesDispatchTransactionService wholeSalesDispatchTransactionService,IRetailSalesDispatchTransactionService retailSalesDispatchTransactionService)
	{
		Title = "Sevk Formu";
        _httpClientService = httpClientService;
		_warehouseService = warehouseService;
        _customerService = customerService;
        _driverService = driverService;
        _carrierService = carrierService;
        _speCodeService = speCodeService;
        _shipInfoService = shipInfoService;
        _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
        _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
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
            await Task.WhenAll(GetCarrierAsync(), GetDriverAsync(),GetCustomerAsync());

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
            var httpClient=_httpClientService.GetOrCreateHttpClient();
            CurrentPage = 0;
            var result = await _customerService.GetObjects(httpClient, SearchText, CustomerOrderBy, CurrentPage, PageSize);

            if(result.Data.Any())
            {
                CustomerItems.Clear();

                foreach(var item in result.Data)
                {
                    await Task.Delay(100);
                    CustomerItems.Add(item);
                }
            }

        }
        catch(Exception ex) 
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error:", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy= false;
        }

    }

    [RelayCommand]
    public async Task GetShipInfoAsync(Customer selectedCustomer)
    {
        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _shipInfoService.GetObjectsByCurrentId(httpClient, selectedCustomer.ReferenceId);

            if (result.Data.Any())
            {
                ShipInfoItems.Clear();

                foreach (var item in result.Data)
                {
                    await Task.Delay(100);
                    ShipInfoItems.Add(item);
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

    async Task RetailSalesDispatchInsert()
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
            retailSalesDispatch.TransactionType = 7;
            //retailSalesDispatch.ShipInfoReferenceId =0;
            //retailSalesDispatch.ShipInfoCode = "";
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            retailSalesDispatch.Description = SalesFormModel.Description;
            retailSalesDispatch.CurrentCode = SelectedCustomer.Code;
            retailSalesDispatch.CurrentReferenceId = SelectedCustomer.ReferenceId;



            foreach (var item in ProductModel)
            {
                RetailSalesDispatchTransactionLineDto retailSalesDispatchLine = new RetailSalesDispatchTransactionLineDto();

                retailSalesDispatchLine.ProductCode = item.Code;
                retailSalesDispatchLine.ProductReferenceId = item.ReferenceId;
                retailSalesDispatchLine.CurrentCode = SelectedCustomer.Code;
                retailSalesDispatchLine.CurrentReferenceId = SelectedCustomer.ReferenceId;
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

            var result = await _retailSalesDispatchTransactionService.InsertObject(httpClient, retailSalesDispatch);
            if (result.IsSuccess)
			{
				var viewModel = _serviceProvider.GetService<SalesDispatchListViewModel>();
				viewModel.Items.Clear();
				viewModel.Results.Clear();
				await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 100,
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
    async Task WholeSalesDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            WholeSalesDispatchTransactionDto wholeSalesDispatchTransactionDto = new WholeSalesDispatchTransactionDto();
            wholeSalesDispatchTransactionDto.WarehouseNumber = Warehouse.Number;
            wholeSalesDispatchTransactionDto.CarrierCode = SalesFormModel.SelectedCarrier.Code;
            wholeSalesDispatchTransactionDto.DriverFirstName = SalesFormModel.SelectedDriver.Name;
            wholeSalesDispatchTransactionDto.DriverLastName = SalesFormModel.SelectedDriver.Surname;
            wholeSalesDispatchTransactionDto.IdentityNumber = SalesFormModel.SelectedDriver.IdentityNumber;
            wholeSalesDispatchTransactionDto.Plaque = SalesFormModel.SelectedDriver.PlateNumber;
            wholeSalesDispatchTransactionDto.TransactionDate = SalesFormModel.TransactionDate;
            wholeSalesDispatchTransactionDto.TransactionType = 8;
            //retailSalesDispatch.ShipInfoReferenceId =0;
            //retailSalesDispatch.ShipInfoCode = "";
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            wholeSalesDispatchTransactionDto.Description = SalesFormModel.Description;
            wholeSalesDispatchTransactionDto.CurrentCode = SelectedCustomer.Code;
            wholeSalesDispatchTransactionDto.CurrentReferenceId = SelectedCustomer.ReferenceId;



            foreach (var item in ProductModel)
            {
                WholeSalesDispatchTransactionLineDto wholeSalesDispatchTransactionLineDto = new WholeSalesDispatchTransactionLineDto();

                wholeSalesDispatchTransactionLineDto.ProductCode = item.Code;
                wholeSalesDispatchTransactionLineDto.ProductReferenceId = item.ReferenceId;
                wholeSalesDispatchTransactionLineDto.CurrentCode = SelectedCustomer.Code;
                wholeSalesDispatchTransactionLineDto.CurrentReferenceId = SelectedCustomer.ReferenceId;
                wholeSalesDispatchTransactionLineDto.Quantity = item.Quantity;
                wholeSalesDispatchTransactionLineDto.UnitsetCode = item.UnitsetCode;
                wholeSalesDispatchTransactionLineDto.UnitsetReferenceId = item.UnitsetReferenceId;
                wholeSalesDispatchTransactionLineDto.TransactionType = 8;
                wholeSalesDispatchTransactionLineDto.SubUnitsetCode = item.SubUnitsetCode;
                wholeSalesDispatchTransactionLineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                wholeSalesDispatchTransactionLineDto.OrderReferenceId = item.ReferenceId;
                wholeSalesDispatchTransactionLineDto.WarehouseNumber = Warehouse.Number;
                wholeSalesDispatchTransactionDto.Lines.Add(wholeSalesDispatchTransactionLineDto);
            }

            var result = await _wholeSalesDispatchTransactionService.InsertObject(httpClient, wholeSalesDispatchTransactionDto);
            if (result.IsSuccess)
            {
                var viewModel = _serviceProvider.GetService<SalesDispatchListViewModel>();
                viewModel.Items.Clear();
                viewModel.Results.Clear();
                await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 100,
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
            if (SelectedTransactionType == null)
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
