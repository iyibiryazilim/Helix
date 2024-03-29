﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels
{

	[QueryProperty(name: nameof(Product), queryId: nameof(Product))] 
    [QueryProperty(nameof(Warehouse), nameof(Warehouse))]

    public partial class ReturnSalesListViewModel :BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseService _warehouseService;
        //WarehouseService
        public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
        public ObservableCollection<Warehouse> Results { get; } = new();

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

        public ReturnSalesListViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
        {

            Title = "Satış İade İşlemleri";
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;

        }

        public ObservableCollection<ProductModel> Items { get; } = new();


        [RelayCommand]
        async Task GoToSharedProductList()
        {
            await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
            {
                ["ViewType"] = 2,
                [nameof(Warehouse)] = Warehouse

            });
        }

        [RelayCommand]
        async Task GoToOperationForm()
        {

            if (Items.Any())
            {

                await Shell.Current.GoToAsync($"{nameof(ReturnSalesFormView)}", new Dictionary<string, object>
                {
                    [nameof(ProductModel)] = Items,
                    [nameof(Warehouse)] = Warehouse
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
					["CurrentPage"] = "ReturnSalesListView"
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
}

