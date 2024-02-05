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
using Java.Nio.Channels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels
{
    [QueryProperty(nameof(TransferTransactionModel), nameof(TransferTransactionModel))]
    public partial class TransferTransactionOperationFormViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        ISpeCodeService _speCodeService;
        IProductionTransactionService _productionTransactionService;
        IConsumableTransactionService _consumableTransactionService;
        IServiceProvider _serviceProvider;

        [ObservableProperty]
        public string speCode = string.Empty;
        [ObservableProperty]
        public string description = string.Empty;

        [ObservableProperty]
        DateTime transactionDate = DateTime.Now;

        [ObservableProperty]
        TimeSpan transactionTime = DateTime.Now.TimeOfDay;

        [ObservableProperty]
        TransferTransactionModel transferTransactionModel;

        public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

        public TransferTransactionOperationFormViewModel(IHttpClientService httpClientService, ISpeCodeService speCodeService, IProductionTransactionService productionTransactionService, IConsumableTransactionService consumableTransactionService, IServiceProvider serviceProvider)
        {
            Title = "Ambar Transfer Formu";
            _httpClientService = httpClientService;
            _speCodeService = speCodeService;
            _consumableTransactionService = consumableTransactionService;
            _productionTransactionService = productionTransactionService;
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
        async Task TransferTransactionInsertAsync()
        {
            try
            {
                IsBusy = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                DateTime combinedDateTime = TransactionDate.Date
                   .AddHours(TransactionTime.Hours)
                   .AddMinutes(TransactionTime.Minutes)
                   .AddSeconds(TransactionTime.Seconds);

                var consumableTransactionDto = new ConsumableTransactionDto()
                {
                    WarehouseNumber = TransferTransactionModel.ExitWarehouse.Number,
                    TransactionDate = combinedDateTime,
                    IOType = 4,
                    Description = Description,
                    TransactionType = 12,
                    GroupType = 3

                };
                foreach (var item in TransferTransactionModel.Products)
                {

                    var consumableTransactionLineDto = new ConsumableTransactionLineDto()
                    {
                        IOType = 4,
                        TransactionType = 12,
                        TransactionDate = combinedDateTime,
                        ProductCode = item.ExitProduct.Code,
                        ProductReferenceId = item.ExitProduct.ReferenceId,
                        Quantity = item.ExitProduct.QuantityCounter,
                        SubUnitsetCode = item.ExitProduct.SubUnitsetCode,
                        SubUnitsetReferenceId = item.ExitProduct.SubUnitsetReferenceId,
                        UnitsetCode = item.ExitProduct.UnitsetCode,
                        UnitsetReferenceId = item.ExitProduct.UnitsetReferenceId,
                        WarehouseNumber = TransferTransactionModel.ExitWarehouse.Number
                    };
                    consumableTransactionDto.Lines.Add(consumableTransactionLineDto);
                }


                var result = await _consumableTransactionService.InsertObject(httpClient, consumableTransactionDto);
                if (result.IsSuccess)
                {

                    var productionTransactionDto = new ProductionTransactionDto()
                    {
                        WarehouseNumber = TransferTransactionModel.EntryWarehouse.Number,
                        TransactionDate = combinedDateTime,
                        IOType = 1,
                        Description = Description,
                        TransactionType = 13,
                        GroupType = 3

                    };
                    foreach (var item in TransferTransactionModel.Products)
                    {

                        var productionTransactionLineDto = new ProductionTransactionLineDto()
                        {
                            IOType = 1,
                            TransactionType = 13,
                            TransactionDate = combinedDateTime,
                            ProductCode = item.EntryProduct.Code,
                            ProductReferenceId = item.EntryProduct.ReferenceId,
                            Quantity = item.EntryProduct.QuantityCounter,
                            SubUnitsetCode = item.EntryProduct.SubUnitsetCode,
                            SubUnitsetReferenceId = item.EntryProduct.SubUnitsetReferenceId,
                            UnitsetCode = item.EntryProduct.UnitsetCode,
                            UnitsetReferenceId = item.EntryProduct.UnitsetReferenceId,
                            WarehouseNumber = TransferTransactionModel.EntryWarehouse.Number
                        };
                        productionTransactionDto.Lines.Add(productionTransactionLineDto);
                    }

                    var ProductionResult = await _productionTransactionService.InsertObject(httpClient, productionTransactionDto);
                    if (ProductionResult.IsSuccess)
                    {
                        var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                        if (userResponse)
                        {
                            await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                            {
                               ["GroupType"] = 8,
                               ["SuccessMessage"] = "Virman Fişi Başarıyla Gönderildi."
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

}

