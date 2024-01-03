using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

public partial class WastageTransactionOperationViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    public WastageTransactionOperationViewModel(IHttpClientService httpClientService)
    {
        Title = "Fire İşlemleri";
        _httpClientService = httpClientService;

    }
    public ObservableCollection<ProductModel> Items { get; } = new();

    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 11
        });
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
    async Task GoToOperationForm()
    {
        await Shell.Current.GoToAsync($"{nameof(WastageTransactionOperationFormView)}");
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
    async Task AddQuantity(ProductModel item)
    {
        if (item.StockQuantity < item.Quantity)
        {
            await Shell.Current.DisplayAlert("Uyarı", "Ekemek istediğiniz miktar stok miktarından stok miktarından fazla", "Kapat");
        }
        else
        {
            item.Quantity++;

        }


    }
    [RelayCommand]

    async Task DeleteQuantity(ProductModel item)
    {
        if (item.Quantity != 1)
            item.Quantity--;


    }
}
