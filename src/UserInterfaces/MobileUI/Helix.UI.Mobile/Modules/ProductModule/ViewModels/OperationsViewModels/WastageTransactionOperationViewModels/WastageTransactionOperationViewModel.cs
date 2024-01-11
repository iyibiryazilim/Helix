﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]

public partial class WastageTransactionOperationViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    public WastageTransactionOperationViewModel(IHttpClientService httpClientService)
    {
        Title = "Fire İşlemleri";
        _httpClientService = httpClientService;

    }
    [ObservableProperty]
    Warehouse warehouse;
    public ObservableCollection<ProductModel> Items { get; } = new();

    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 11,
            ["Warehouse"] = Warehouse
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
        if (Items.Any())
        {

            await Shell.Current.GoToAsync($"{nameof(WastageTransactionOperationFormView)}", new Dictionary<string, object>
            {
                [nameof(ProductModel)] = Items,
                ["Warehouse"] = Warehouse
            });
        }

        else
        {
            await Shell.Current.DisplayAlert("Uyarı ", $"Ürün seçmediniz", "Kapat");
        }
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
        item.Quantity++;

    }
    [RelayCommand]

    async Task DeleteQuantity(ProductModel item)
    {
        if (item.Quantity != 1)
            item.Quantity--;


    }
}
