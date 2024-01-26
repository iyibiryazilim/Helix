﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationFormViewModel;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

public partial class InCountingTransactionOperationFormViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    ISpeCodeService _speCodeService;
    IInCountingTransactionService _inCountingTransactionService;
    //WarehouseService
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();

    [ObservableProperty]
    string transactionTypeName;

    [ObservableProperty]
    ProductTransactionFormModel productTransactionFormModel = new();

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
    [ObservableProperty]
    ObservableCollection<ProductModel> productModel;

    //speCode
    [ObservableProperty]
    public string speCode = string.Empty;

    public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

    public InCountingTransactionOperationFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISpeCodeService speCodeService,IInCountingTransactionService inCountingTransactionService)
    {
        Title = "Sayım Fazlası İşlemleri";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _speCodeService = speCodeService;
        _inCountingTransactionService = inCountingTransactionService;
        TransactionTypeName = "Sayım Fazlası Fişi";

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
            foreach (var item in ProductModel)
            {

                var inCountingTransactionLineDto = new InCountingTransactionLineDto()
                {
                    IOType = 1,
                    TransactionType = 50,
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
                inCountingTransactionDto.Lines.Add(inCountingTransactionLineDto);
            }


            var result = await _inCountingTransactionService.InsertObject(httpClient, inCountingTransactionDto);
            if (result.IsSuccess)
            {
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
