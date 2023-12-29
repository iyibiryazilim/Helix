using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Diagnostics;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;


namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

public partial class ConsumableTransactionOperationViewModel : BaseViewModel 
{
    IHttpClientService _httpClientService;
    public ConsumableTransactionOperationViewModel(IHttpClientService httpClientService)
    {
        Title = "Sarf İşlemleri";
        _httpClientService = httpClientService;
    }

    public ObservableCollection<ProductModel> Items { get; } = new();


    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 12
        });
    }
    [RelayCommand]
    async Task GoToConsumableTransactionForm()
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
    async Task Deneme()
    {
        await Shell.Current.DisplayAlert(Title, Items.FirstOrDefault().Name, "tamam");

    }

    [RelayCommand]
    async Task AddQuantity(ProductModel item)
    {
        if ( item.StockQuantity< item.Quantity)
        {
            bool result = await Shell.Current.DisplayAlert("Uyarı","Ekemek istediğiniz miktar stok miktarından stok miktarından fazla","Ekle","Vazgeç");
            if (result)
            {
                item.Quantity++;
            }

        }
        else
        {
            item.Quantity++;
            
        }
       

    }
    [RelayCommand]

    async Task DeleteQuantity  (ProductModel item)
    {
        if (item.Quantity !=1)
        item.Quantity--;
        
       
    }






}
