using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]

public partial class ProductionTransactionOperationViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;

    public Command SearchCommand { get; }
    public ProductionTransactionOperationViewModel(IHttpClientService httpClientService)
    {
        Title = "Üretimden Giriş İşlemleri";
        _httpClientService = httpClientService;

        SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
    }
    public ObservableCollection<ProductModel> Items { get; } = new();
    public ObservableCollection<ProductModel> Results { get; } = new();

    [ObservableProperty]
    Warehouse warehouse;

    [ObservableProperty]
    string searchText = String.Empty;

    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 13,
            ["Warehouse"] = Warehouse
        });
    }

    [RelayCommand]
    async Task GoToOperationForm()
    {
        if (Items.Any())
        {
           
            await Shell.Current.GoToAsync($"{nameof(ProductionTransactionOperationFormView)}", new Dictionary<string, object>
            {
                [nameof(ProductModel)] = Items,
                ["Warehouse"] = Warehouse
            });
        }

        else
        {
            await Shell.Current.DisplayAlert("Uyarı ", $"Malzeme seçmediniz", "Kapat");
        }

    }

    [RelayCommand]
    async Task GetBack()
    {
        if (Items.Count == 0)
            await Shell.Current.GoToAsync("..");
        else
        {
            bool answer = await Shell.Current.DisplayAlert("Bilgilendirme", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");

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
    async Task RemoveItemAsync(ProductModel item)
    {

        try
        {

            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.Name} adlı malzeme çıkartılacaktır. Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
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
        item.Quantity++;
        //if (item.StockQuantity < item.Quantity)
        //{
        //    await Shell.Current.DisplayAlert("Uyarı", "Ekemek istediğiniz miktar stok miktarından stok miktarından fazla", "Kapat");
        //}
        //else
        //{
        //    item.Quantity++;

        //}


    }
    [RelayCommand]

    async Task DeleteQuantity(ProductModel item)
    {
        if (item.Quantity != 1)
            item.Quantity--;


    }

    async Task PerformSearchAsync(string text)
    {
        if (IsBusy)
            return;
        try
        {
            if (!string.IsNullOrEmpty(text))
            {
                if(text.Length >= 3)
                {
                    SearchText = text.ToLower();
                    Results.Clear();
                    foreach(var item in Items.ToList().Where(x => x.Name.ToLower().Contains(SearchText) || x.Code.ToString().ToLower().Contains(SearchText)))
                    {
                        Results.Add(item);
                    }
                }
            }
            else
            {
                SearchText = String.Empty;
                Results.Clear();
                foreach(var item in Items)
                {
					Results.Add(item);
				}
            }
        }
        catch(Exception ex)
        {
			Debug.WriteLine(ex);
			await Application.Current.MainPage.DisplayAlert("Search Error :", ex.Message, "Tamam");
		}
        finally
        {
            IsBusy = false;
        }
    }

	[RelayCommand]
	async Task GoToBarcodePageViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(BarcodePageView)}", new Dictionary<string, object>
			{
				["CurrentPage"] = "ProductionTransactionOperationView"
			});

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
