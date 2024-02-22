using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

public partial class OutCountingTransactionOperationFormViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    ISpeCodeService _speCodeService;
    IOutCountingTransactionService _outCountingTransactionService;
    IServiceProvider _serviceProvider;
    //WarehouseService
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();

    [ObservableProperty]
    string transactionTypeName;

    [ObservableProperty]
    ProductTransactionFormModel productTransactionFormModel = new();
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
    Warehouse warehouse;
    //speCode
    [ObservableProperty]
    public string speCode = string.Empty;

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();


    public OutCountingTransactionOperationFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISpeCodeService speCodeService, IOutCountingTransactionService outCountingTransactionService,IServiceProvider serviceProvider)
    {
        Title = "Sayım Eksikliği İşlemleri";
        _httpClientService= httpClientService;
        _warehouseService= warehouseService;
        _speCodeService= speCodeService;
        _outCountingTransactionService = outCountingTransactionService;
        _serviceProvider = serviceProvider;
        transactionTypeName = "Sayım Eksiği Fişi";


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
    async Task GoToSuccessPageView()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            DateTime combinedDateTime = ProductTransactionFormModel.TransactionDate.Date
               .AddHours(ProductTransactionFormModel.TransactionTime.Hours)
               .AddMinutes(ProductTransactionFormModel.TransactionTime.Minutes)
               .AddSeconds(ProductTransactionFormModel.TransactionTime.Seconds);
            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");


            var outCountingTransactionDto = new OutCountingTransactionDto()
            {
                WarehouseNumber = Warehouse.Number,
                TransactionDate = combinedDateTime,
                DoCode = ProductTransactionFormModel.DocumentryNo,
                DocTrackingNumber = ProductTransactionFormModel.DocumentryTrackingNo,
                IOType = 4,
                Description = ProductTransactionFormModel.Description,
                TransactionType = 51,
                GroupType = 3,
                EmployeeOid = employeeOid

            };
            foreach (var item in ProductModel)
            {

                var outCountingTransactionLineDto = new OutCountingTransactionLineDto()
                {
                    IOType = 4,
                    TransactionType = 51,
                    TransactionDate = combinedDateTime,
                    ProductCode = item.Code,
                    ProductReferenceId = item.ReferenceId,
                    Quantity = item.Quantity,
                    SubUnitsetCode = item.SubUnitsetCode,
                    SubUnitsetReferenceId = item.SubUnitsetReferenceId,
                    UnitsetCode = item.UnitsetCode,
                    UnitsetReferenceId = item.UnitsetReferenceId,
                    WarehouseNumber = Warehouse.Number
                };
                outCountingTransactionDto.Lines.Add(outCountingTransactionLineDto);
            }


            var result = await _outCountingTransactionService.InsertObject(httpClient, outCountingTransactionDto);
            if (result.IsSuccess)
            {

                var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                if (userResponse)
                {
                   var viewModel = _serviceProvider.GetService<OutCountingTransactionOperationViewModel>();
                    viewModel.Items.Clear();

                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 3,
                        ["SuccessMessage"]="Sayım Eksiği Fişi Başarıyla Gönderildi."
                    });
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
            }

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            IsBusy = false;
        }


    }

}
