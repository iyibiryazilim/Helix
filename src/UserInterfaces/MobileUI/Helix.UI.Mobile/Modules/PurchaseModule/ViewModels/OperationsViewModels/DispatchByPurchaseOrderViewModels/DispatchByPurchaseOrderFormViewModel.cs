using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
    [QueryProperty(nameof(Warehouse), nameof(Warehouse))]
    [QueryProperty(nameof(ChangedLines), nameof(ChangedLines))]
    public partial class DispatchByPurchaseOrderFormViewModel :BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseService _warehouseService;
        ISupplierService _supplierService;
        ISpeCodeService _speCodeService;
        IPurchaseDispatchTransactionService _purchaseDispatchTransaction;

        public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
        public ObservableCollection<Supplier> SupplierItems { get; } = new();


        [ObservableProperty]
        ObservableCollection<WaitingOrderLine> changedLines;
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
        SupplierOrderBy supplierOrderBy = SupplierOrderBy.nameasc;

        [ObservableProperty]
        PurchaseFormModel purchaseFormModel = new();
        //speCode
        [ObservableProperty]
        public string speCode = string.Empty;

        [ObservableProperty]
        Supplier current;
        [ObservableProperty]
        Warehouse warehouse;
        [ObservableProperty]
        public bool isVisible = false;

        [ObservableProperty]
        public bool isNotVisible = true;

        public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

        public DispatchByPurchaseOrderFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISupplierService supplierService,ISpeCodeService speCodeService,IPurchaseDispatchTransactionService purchaseDispatchTransaction)
        {
            Title = "Satın Alma Form";
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;
            _supplierService= supplierService;
            _speCodeService = speCodeService;
            _purchaseDispatchTransaction = purchaseDispatchTransaction;

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
                purchaseDispatchTransactionDto.CurrentCode = ChangedLines.FirstOrDefault().CurrentCode;
                purchaseDispatchTransactionDto.CurrentReferenceId = ChangedLines.FirstOrDefault().CurrentReferenceId;



                foreach (var item in ChangedLines)
                {
                    PurchaseDispatchTransactionLineDto purchaseDispatchLine = new PurchaseDispatchTransactionLineDto();

                    purchaseDispatchLine.ProductCode = item.ProductCode;
                    purchaseDispatchLine.ProductReferenceId = item.ProductReferenceId;
                    purchaseDispatchLine.CurrentCode = item.CurrentCode;
                    purchaseDispatchLine.CurrentReferenceId = item.CurrentReferenceId;
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
                            ["GroupType"] = 1
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
}
