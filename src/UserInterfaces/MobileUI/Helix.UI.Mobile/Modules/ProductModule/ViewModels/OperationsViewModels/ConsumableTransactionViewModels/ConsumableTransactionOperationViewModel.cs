using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Diagnostics;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;


namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

public partial class ConsumableTransactionOperationViewModel : BaseViewModel 
{
    IHttpClientService _httpClientService;
    IWarehouseService _warehouseService;
    //WarehouseService
    public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
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


    public ConsumableTransactionOperationViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
    {
        Title = "Sarf İşlemleri";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;

    }

    public ObservableCollection<ProductModel> Items { get; } = new();

    
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
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 12
        });
    }

    [RelayCommand]
    async Task GoToOperationForm()
    {
        await Shell.Current.GoToAsync($"{nameof(ConsumableTransactionOperationFormView)}");
    }

    [RelayCommand]
    async Task RemoveItemAsync(ProductModel item)
    {

        if (IsBusy)
            return;

        try
        {

            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.Name} ürün çıkartılacaktır.Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
            if (answer)
                Items.Remove(item);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error : ", $"Bir Hata Oluştu:{ex.Message}", "Kapat");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GetBack()
    {
        if (Items.Count == 0)
            await Shell.Current.GoToAsync("..");
        else
        {
            bool answer = await Shell.Current.DisplayAlert("Sayım Eksiği :: Vazgeç", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");

            if (answer)
            {
                await Shell.Current.GoToAsync("..");
                Items.Clear();
            }
            else
            {
                
            }

        }
    }


    [RelayCommand]
    async Task AddQuantity(ProductModel item)
    {

        item.Quantity++;

        //if ( item.StockQuantity< item.Quantity)
        //{
        //    bool result = await Shell.Current.DisplayAlert("Uyarı","Ekemek istediğiniz miktar stok miktarından stok miktarından fazla","Ekle","Vazgeç");
        //    if (result)
        //    {
        //        item.Quantity++;
        //    }

        //}
        //else
        //{
        //    item.Quantity++;
            
        //}
       

    }
    [RelayCommand]

    async Task DeleteQuantity  (ProductModel item)
    {
        if (item.Quantity !=1)
        item.Quantity--;
        
       
    }






}
