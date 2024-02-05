using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

public partial class ReturnPurchaseFormViewModel :BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    IDriverService _driverService;
    ICarrierService _carrierService;
    ISupplierService _supplierService;
    IShipInfoService _shipInfoService;
    IServiceProvider _serviceProvider;
    ISpeCodeService _speCodeService;
    IPurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;

    public ObservableCollection<Driver> DriverItems { get; } = new();

    public ObservableCollection<Carrier> CarrierItems { get; } = new();
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();

    public ObservableCollection<ShipInfo> ShipInfoItems { get; } = new();

    public ObservableCollection<Supplier> Suppliers { get; } = new();

    [ObservableProperty]
    string transactionTypeName;

    [ObservableProperty]
    SalesFormModel salesFormModel = new();

    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    ProductOrderBy orderBy = ProductOrderBy.nameasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 99999;
    [ObservableProperty]
    WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;

    [ObservableProperty]
    SupplierOrderBy supplierOrderBy = SupplierOrderBy.codeasc;

    [ObservableProperty]
    Warehouse warehouse;

    [ObservableProperty]
    ObservableCollection<ProductModel> productModel;

    [ObservableProperty]
    public string speCode = string.Empty;

    [ObservableProperty]
    public bool isVisible = true;

    [ObservableProperty]
    public bool isNotVisible = false;

    private Supplier selectedSupplier;

    public Supplier SelectedSupplier
    {
        get => selectedSupplier;
        set
        {
            SetProperty(ref selectedSupplier, value);
            Task.Run(async () => await GetShipInfoAsync(value));
        }
    }
    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

    public ReturnPurchaseFormViewModel(IHttpClientService httpClientService,
									   IWarehouseService warehouseService,
									   ISpeCodeService speCodeService,
									   IDriverService driverService,
									   ICarrierService carrierService,
									   ISupplierService supplierService,
									   IShipInfoService shipInfoService,
									   IPurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService,
                                       IServiceProvider serviceProvider)
    {
        Title = "Satın Alma İade Fişleri";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _speCodeService = speCodeService;
        _driverService = driverService;
        _carrierService = carrierService;
        _supplierService = supplierService;
        _shipInfoService = shipInfoService;
        _serviceProvider = serviceProvider;
        _purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
        TransactionTypeName = "Satın Alma İade İrsaliyesi";
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
            await Task.WhenAll(GetSupplierAsync(), GetCarrierAsync(), GetDriverAsync());

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
    public async Task GetShipInfoAsync(Supplier selectedSupplier)
    {
        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _shipInfoService.GetObjectsByCurrentId(httpClient, selectedSupplier.ReferenceId);

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
    public async Task GetSupplierAsync()
    {
        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            CurrentPage = 0;
            var result = await _supplierService.GetObjects(httpClient, SearchText, SupplierOrderBy, CurrentPage, PageSize);

            if (result.Data.Any())
            {
                Suppliers.Clear();

                foreach (var item in result.Data)
                {
                    await Task.Delay(100);
                    Suppliers.Add(item);
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

    [RelayCommand]
    async Task PurchaseDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            PurchaseReturnDispatchTransactionInsertDto purchaseDispatchTransactionDto = new PurchaseReturnDispatchTransactionInsertDto();
            purchaseDispatchTransactionDto.WarehouseNumber = Warehouse.Number;
            purchaseDispatchTransactionDto.TransactionDate = SalesFormModel.TransactionDate;
            purchaseDispatchTransactionDto.TransactionType = 1;
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            purchaseDispatchTransactionDto.Description = SalesFormModel.Description;
            purchaseDispatchTransactionDto.CurrentCode = SelectedSupplier.Code;
            purchaseDispatchTransactionDto.IOType = 4;
            purchaseDispatchTransactionDto.CurrentReferenceId = SelectedSupplier.ReferenceId;



            foreach (var item in ProductModel)
            {
                PurchaseReturnDispatchTransactionLineDto purchaseDispatchLine = new PurchaseReturnDispatchTransactionLineDto();

                purchaseDispatchLine.ProductCode = item.Code;
                purchaseDispatchLine.ProductReferenceId = item.ReferenceId;
                purchaseDispatchLine.CurrentCode = SelectedSupplier.Code;
                purchaseDispatchLine.CurrentReferenceId = SelectedSupplier.ReferenceId;
                purchaseDispatchLine.Quantity = item.Quantity;
                purchaseDispatchLine.UnitsetCode = item.UnitsetCode;
                purchaseDispatchLine.UnitsetReferenceId = item.UnitsetReferenceId;
                purchaseDispatchLine.TransactionType = 6;
                purchaseDispatchLine.IOType = 4;
                purchaseDispatchLine.SubUnitsetCode = item.SubUnitsetCode;
                purchaseDispatchLine.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                purchaseDispatchLine.WarehouseNumber = Warehouse.Number;
                purchaseDispatchTransactionDto.Lines.Add(purchaseDispatchLine);
            }

            var result = await _purchaseReturnDispatchTransactionService.InsertObject(httpClient, purchaseDispatchTransactionDto);
            if (result.IsSuccess)
            {
                var viewModel = _serviceProvider.GetService<ReturnPurchaseListViewModel>();
                viewModel.Items.Clear();
               
                await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 3
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

}
