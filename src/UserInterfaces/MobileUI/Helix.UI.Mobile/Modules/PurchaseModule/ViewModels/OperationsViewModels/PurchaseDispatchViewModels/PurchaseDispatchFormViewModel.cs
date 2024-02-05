using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class PurchaseDispatchFormViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    ISupplierService _supplierService;
    ISpeCodeService _speCodeService;
    IPurchaseDispatchTransactionService _purchaseDispatchTransaction;

    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
    public ObservableCollection<Supplier> SupplierItems { get; } = new();


    [ObservableProperty]
    ObservableCollection<ProductModel> productModel;
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
    SupplierOrderBy supplierOrderBy = SupplierOrderBy.nameasc;

    [ObservableProperty]
    PurchaseFormModel purchaseFormModel = new();

    [ObservableProperty]
    Warehouse warehouse;

    [ObservableProperty]
    public bool isVisible = true;

    [ObservableProperty]
    public bool isNotVisible = false;
    //speCode
    [ObservableProperty]
    public string speCode = string.Empty;

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

    public PurchaseDispatchFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISupplierService supplierService, ISpeCodeService speCodeService, IPurchaseDispatchTransactionService purchaseDispatchTransactionService)
    {
        Title = "Mal Kabul Formu";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _supplierService = supplierService;
        _speCodeService = speCodeService;
        _purchaseDispatchTransaction = purchaseDispatchTransactionService;
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
            await MainThread.InvokeOnMainThreadAsync(GetSupplierAsync);

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
    public async Task GetSupplierAsync()
    {
        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            CurrentPage = 0;
            var result = await _supplierService.GetObjects(httpClient, SearchText, SupplierOrderBy, CurrentPage, PageSize);

            if (result.Data.Any())
            {
                SupplierItems.Clear();

                foreach (var item in result.Data)
                {
                    await Task.Delay(100);
                    SupplierItems.Add(item);
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

            PurchaseDispatchTransactionDto purchaseDispatchTransactionDto = new PurchaseDispatchTransactionDto();
            purchaseDispatchTransactionDto.WarehouseNumber = Warehouse.Number;
            purchaseDispatchTransactionDto.TransactionDate = PurchaseFormModel.TransactionDate;
            purchaseDispatchTransactionDto.TransactionType = 1;
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            purchaseDispatchTransactionDto.Description = PurchaseFormModel.Description;
            purchaseDispatchTransactionDto.CurrentCode = PurchaseFormModel.SelectedSupplier.Code;
            purchaseDispatchTransactionDto.CurrentReferenceId = PurchaseFormModel.SelectedSupplier.ReferenceId;



            foreach (var item in ProductModel)
            {
                PurchaseDispatchTransactionLineDto purchaseDispatchLine = new PurchaseDispatchTransactionLineDto();

                purchaseDispatchLine.ProductCode = item.Code;
                purchaseDispatchLine.ProductReferenceId = item.ReferenceId;
                purchaseDispatchLine.CurrentCode = PurchaseFormModel.SelectedSupplier.Code;
                purchaseDispatchLine.CurrentReferenceId = PurchaseFormModel.SelectedSupplier.ReferenceId;
                purchaseDispatchLine.Quantity = item.Quantity;
                purchaseDispatchLine.UnitsetCode = item.UnitsetCode;
                purchaseDispatchLine.UnitsetReferenceId = item.UnitsetReferenceId;
                purchaseDispatchLine.TransactionType = 1;
                purchaseDispatchLine.SubUnitsetCode = item.SubUnitsetCode;
                purchaseDispatchLine.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                purchaseDispatchLine.OrderReferenceId = item.ReferenceId;
                purchaseDispatchLine.WarehouseNumber = Warehouse.Number;
                purchaseDispatchTransactionDto.Lines.Add(purchaseDispatchLine);
            }

            var result = await _purchaseDispatchTransaction.InsertObject(httpClient, purchaseDispatchTransactionDto);
            if (result.IsSuccess)
            {
                var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                if (userResponse)
                {
                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 100,
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
}