using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

public partial class OutCountingTransactionOperationViewModel: BaseViewModel
{
    IHttpClientService _httpClientService;
    public OutCountingTransactionOperationViewModel(IHttpClientService httpClientService)
    {
        Title = "Sayım Eksikliği İşlemleri";
        _httpClientService = httpClientService;
    }

    public ObservableCollection<ProductModel> Items { get; } = new();

    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 51
        });
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
}
