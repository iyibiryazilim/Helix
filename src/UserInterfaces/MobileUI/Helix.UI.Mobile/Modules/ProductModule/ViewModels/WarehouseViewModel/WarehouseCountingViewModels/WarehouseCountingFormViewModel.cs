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

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels
{
    [QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
    [QueryProperty(name: nameof(SelectedProducts), queryId: nameof(SelectedProducts))]
    public partial class WarehouseCountingFormViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        ISpeCodeService _speCodeService;
        IInCountingTransactionService _inCountingTransactionService;
        IOutCountingTransactionService _outCountingTransactionService;
        IServiceProvider _serviceProvider;
        //WarehouseService

        [ObservableProperty]
        string transactionTypeName;

        [ObservableProperty]
        ProductTransactionFormModel productTransactionFormModel = new();

        [ObservableProperty]
        string searchText = string.Empty;

        [ObservableProperty]
        Warehouse warehouse;

        [ObservableProperty]
        ObservableCollection<WarehouseTotal> selectedProducts;

        //speCode
        [ObservableProperty]
        public string speCode = string.Empty;

        public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

        public WarehouseCountingFormViewModel(IHttpClientService httpClientService, ISpeCodeService speCodeService, IInCountingTransactionService inCountingTransactionService, IOutCountingTransactionService outCountingTransactionService,IServiceProvider serviceProvider)
        {
            Title = "Ambar Sayım İşlemleri";
            _httpClientService = httpClientService;
            _speCodeService = speCodeService;
            _inCountingTransactionService = inCountingTransactionService;
            _outCountingTransactionService = outCountingTransactionService;
            _serviceProvider = serviceProvider;
            TransactionTypeName = "Ambar Sayım";
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
        async Task GoToSuccessPageView()
        {
            try
            {
                IsBusy = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                bool inCountingIsTrue = false;
                bool outCountingIsTrue = false;


                DateTime combinedDateTime = ProductTransactionFormModel.TransactionDate.Date
                   .AddHours(ProductTransactionFormModel.TransactionTime.Hours)
                   .AddMinutes(ProductTransactionFormModel.TransactionTime.Minutes)
                   .AddSeconds(ProductTransactionFormModel.TransactionTime.Seconds);

                bool inCountingIsExist = SelectedProducts.Any(item => item.OnHand < item.TempOnhand);
                if (inCountingIsExist)
                {
                    var inCountingTransactionDto = new InCountingTransactionDto()
                    {
                        WarehouseNumber = Warehouse.Number,
                        TransactionDate = combinedDateTime,
                        DoCode = ProductTransactionFormModel.DocumentryNo,
                        DocTrackingNumber = ProductTransactionFormModel.DocumentryTrackingNo,
                        IOType = 1,
                        Description = ProductTransactionFormModel.Description,
                        TransactionType = 50,
                        GroupType = 3

                    };
                    foreach (var item in SelectedProducts)
                    {
                        if (item.OnHand < item.TempOnhand)
                        {
                            var inCountingTransactionLineDto = new InCountingTransactionLineDto()
                            {
                                IOType = 1,
                                TransactionType = 50,
                                TransactionDate = combinedDateTime,
                                ProductCode = item.ProductCode,
                                ProductReferenceId = item.ProductReferenceId,
                                Quantity = (item.TempOnhand - item.OnHand),
                                SubUnitsetCode = item.SubUnitsetCode,
                                SubUnitsetReferenceId = item.SubUnitsetReferenceId,
                                UnitsetCode = item.UnitsetCode,
                                UnitsetReferenceId = item.UnitsetReferenceId,
                                WarehouseNumber = Warehouse.Number
                            };
                            inCountingTransactionDto.Lines.Add(inCountingTransactionLineDto);

                        }
                    }

                    var result = await _inCountingTransactionService.InsertObject(httpClient, inCountingTransactionDto);
                    if (result.IsSuccess)
                    {
                        inCountingIsTrue = true;
                    }

                }

                bool outCountingIsExist = SelectedProducts.Any(item => item.OnHand > item.TempOnhand);
                if (outCountingIsExist)
                {
                    var outCountingTransactionDto = new OutCountingTransactionDto()
                    {
                        WarehouseNumber = Warehouse.Number,
                        TransactionDate = combinedDateTime,
                        DoCode = ProductTransactionFormModel.DocumentryNo,
                        DocTrackingNumber = ProductTransactionFormModel.DocumentryTrackingNo,
                        IOType = 4,
                        Description = ProductTransactionFormModel.Description,
                        TransactionType = 51,
                        GroupType = 3

                    };

                    foreach (var item in SelectedProducts)
                    {
                        if (item.OnHand > item.TempOnhand)
                        {
                            var outCountingTransactionLineDto = new OutCountingTransactionLineDto()
                            {
                                IOType = 4,
                                TransactionType = 51,
                                TransactionDate = combinedDateTime,
                                ProductCode = item.ProductCode,
                                ProductReferenceId = item.ProductReferenceId,
                                Quantity = (item.OnHand - item.TempOnhand),
                                SubUnitsetCode = item.SubUnitsetCode,
                                SubUnitsetReferenceId = item.SubUnitsetReferenceId,
                                UnitsetCode = item.UnitsetCode,
                                UnitsetReferenceId = item.UnitsetReferenceId,
                                WarehouseNumber = Warehouse.Number
                            };
                            outCountingTransactionDto.Lines.Add(outCountingTransactionLineDto);

                        }
                    }

                    var result = await _outCountingTransactionService.InsertObject(httpClient, outCountingTransactionDto);
                    if (result.IsSuccess)
                    {
                        outCountingIsTrue = true;
                    }

                }

                if (inCountingIsTrue && outCountingIsTrue)
                {
                    var viewModel = _serviceProvider.GetService<WarehouseCountingListViewModel>();
                    viewModel.Items.Clear();
                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 10,
                        ["SuccessMessage"] = "Ambar Sayım Fişi Başarıyla Gönderildi."
                    });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Hata", "Hata", "Tamam");
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
