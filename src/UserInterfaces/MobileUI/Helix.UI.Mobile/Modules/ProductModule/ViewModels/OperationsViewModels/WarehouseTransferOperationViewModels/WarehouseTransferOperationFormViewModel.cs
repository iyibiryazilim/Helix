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

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
[QueryProperty(name: nameof(WarehouseTotal), queryId: nameof(WarehouseTotal))]
public partial class WarehouseTransferOperationFormViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
    ISpeCodeService _speCodeService;
    ITransferTransactionService _transferTransactionService;
    IServiceProvider _serviceProvider;

	[ObservableProperty]
	Warehouse warehouse;

	[ObservableProperty]
	Warehouse selectedWarehouse;

    [ObservableProperty]
    ObservableCollection<WarehouseTotal> warehouseTotal;

    [ObservableProperty]
    public string speCode = string.Empty;
    [ObservableProperty]
    public string description = string.Empty;

    [ObservableProperty]
    DateTime transactionDate = DateTime.Now;

    [ObservableProperty]
    TimeSpan transactionTime = DateTime.Now.TimeOfDay;

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

    public WarehouseTransferOperationFormViewModel(IHttpClientService httpClientService,ISpeCodeService speCodeService,ITransferTransactionService transferTransactionService,IServiceProvider serviceProvider)
	{
		Title = "Ambar Transfer Formu";
		_httpClientService = httpClientService;
        _speCodeService = speCodeService;
        _transferTransactionService = transferTransactionService;
        _serviceProvider = serviceProvider;

	}

    [RelayCommand]
    public async Task GetSpeCodeAsync()
    {
        string action;

        try
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
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
	async Task GoToSuccessPageViewAsync()
	{
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            DateTime combinedDateTime = TransactionDate.Date
               .AddHours(TransactionTime.Hours)
               .AddMinutes(TransactionTime.Minutes)
               .AddSeconds(TransactionTime.Seconds);

            var transferTransactionDto = new TransferTransactionDto()
            {
                WarehouseNumber = Warehouse.Number,
                DestinationWarehouseNumber = SelectedWarehouse.Number,
                TransactionDate = combinedDateTime,
                Description = Description,
                TransactionType = 25,
                GroupType = 3

            };
            foreach (var item in WarehouseTotal)
            {

                var transferTransactionLineDto = new TransferTransactionLineDto()
                {
                    TransactionType = 25,
                    TransactionDate = combinedDateTime,
                    ProductCode = item.ProductCode,
                    ProductReferenceId = item.ProductReferenceId,
                    DestinationWarehouseNumber = SelectedWarehouse.Number,
                    Quantity = item.QuantityCounter,
                    SubUnitsetCode = item.SubUnitsetCode,
                    SubUnitsetReferenceId = item.SubUnitsetReferenceId,
                    UnitsetCode = item.UnitsetCode,
                    UnitsetReferenceId = item.UnitsetReferenceId,
                    WarehouseNumber = Warehouse.Number
                };
                transferTransactionDto.Lines.Add(transferTransactionLineDto);
            }


            var result = await _transferTransactionService.InsertObject(httpClient, transferTransactionDto);
            if (result.IsSuccess)
            {
                var viewModel = _serviceProvider.GetService<WarehouseTransferOperationViewModel>();
                viewModel.Items.Clear();
                await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 8,
                    ["SuccessMessage"] = "Ambar Transfer Fişi Başarıyla Gönderildi."
                });
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
