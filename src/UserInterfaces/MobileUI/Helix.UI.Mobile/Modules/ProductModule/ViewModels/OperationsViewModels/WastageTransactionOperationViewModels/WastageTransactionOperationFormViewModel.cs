using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

public partial class WastageTransactionOperationFormViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    //WarehouseService
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();

    [ObservableProperty]
    string transactionTypeName;

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
    public WastageTransactionOperationFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService )
    {
        Title = "Fire İşlemleri";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        TransactionTypeName = "Fire Fişi";
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


}
