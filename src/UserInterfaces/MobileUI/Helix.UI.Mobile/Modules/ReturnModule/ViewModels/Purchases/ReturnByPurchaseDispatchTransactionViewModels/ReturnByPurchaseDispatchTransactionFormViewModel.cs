using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
    [QueryProperty(nameof(Current), nameof(Current))]
    [QueryProperty(nameof(Warehouse), nameof(Warehouse))]
    [QueryProperty(nameof(ShipInfo), nameof(ShipInfo))]
    [QueryProperty(nameof(ChangedLineList), nameof(ChangedLineList))]
	public partial class ReturnByPurchaseDispatchTransactionFormViewModel : BaseViewModel
	{
        IHttpClientService _httpClientService;
        IDriverService _driverService;
        ICarrierService _carrierService;
        ISpeCodeService _speCodeService;
        IPurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;

        [ObservableProperty]
        ObservableCollection<DispatchTransactionLine> changedLineList;

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
        public string speCode = string.Empty;

        [ObservableProperty]
        SalesFormModel salesFormModel = new();

        [ObservableProperty]
        Supplier current;

        [ObservableProperty]
        Warehouse warehouse;

        [ObservableProperty]
        string selectedTransactionType;

        [ObservableProperty]
        ShipInfo shipInfo;

        [ObservableProperty]
        public bool isVisible = false;

        [ObservableProperty]
        public bool isNotVisible = true;

        public ReturnByPurchaseDispatchTransactionFormViewModel(IHttpClientService httpClientService, IDriverService driverService, ICarrierService carrierService, ISpeCodeService speCodeService, IPurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService)
        {
            Title = "Form";
            _httpClientService = httpClientService;
            _driverService = driverService;
            _carrierService = carrierService;
            _speCodeService = speCodeService;
            _purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
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

        [RelayCommand]
        async Task PurchaseDispatchInsert()
        {
            try
            {
                IsBusy = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var employeeOid = await SecureStorage.GetAsync("EmployeeOid");


                PurchaseReturnDispatchTransactionInsertDto purchaseDispatchTransactionDto = new PurchaseReturnDispatchTransactionInsertDto();
                purchaseDispatchTransactionDto.WarehouseNumber = Warehouse.Number;
                purchaseDispatchTransactionDto.TransactionDate = SalesFormModel.TransactionDate;
                purchaseDispatchTransactionDto.TransactionType = 1;
                //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
                purchaseDispatchTransactionDto.Description = SalesFormModel.Description;
                purchaseDispatchTransactionDto.IOType = 4;
                purchaseDispatchTransactionDto.CurrentCode = ChangedLineList.FirstOrDefault().CurrentCode;
                purchaseDispatchTransactionDto.CurrentReferenceId = ChangedLineList.FirstOrDefault().CurrentReferenceId;
                purchaseDispatchTransactionDto.EmployeeOid = employeeOid;



                foreach (var item in ChangedLineList)
                {
                    PurchaseReturnDispatchTransactionLineDto purchaseDispatchLine = new PurchaseReturnDispatchTransactionLineDto();

                    purchaseDispatchLine.ProductCode = item.ProductCode;
                    purchaseDispatchLine.ProductReferenceId = item.ProductReferenceId;
                    purchaseDispatchLine.CurrentCode = item.CurrentCode;
                    purchaseDispatchLine.CurrentReferenceId = item.CurrentReferenceId;
                    purchaseDispatchLine.Quantity = item.Quantity;
                    purchaseDispatchLine.UnitsetCode = item.UnitsetCode;
                    purchaseDispatchLine.UnitsetReferenceId = item.UnitsetReferenceId;
                    purchaseDispatchLine.TransactionType = 6;
                    purchaseDispatchLine.IOType = 4;
                    purchaseDispatchLine.SubUnitsetCode = item.SubUnitsetCode;
                    purchaseDispatchLine.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                    purchaseDispatchLine.WarehouseNumber = Warehouse.Number;
                    purchaseDispatchLine.DispatchReferenceId = item.ReferenceId;
                    purchaseDispatchTransactionDto.Lines.Add(purchaseDispatchLine);
                }

                var result = await _purchaseReturnDispatchTransactionService.InsertObject(httpClient, purchaseDispatchTransactionDto);
                if (result.IsSuccess)
                {
                    var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                    if (userResponse)
                    {
                        await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                        {
                            ["GroupType"] = 2,
                            ["SuccessMessage"] = "İade İrsaliyesi Başarıyla Gönderildi."
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
