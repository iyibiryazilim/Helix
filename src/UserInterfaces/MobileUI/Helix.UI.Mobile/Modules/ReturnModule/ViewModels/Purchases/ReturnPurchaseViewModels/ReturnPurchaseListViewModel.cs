﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels
{
    [QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]

    public partial class ReturnPurchaseListViewModel :BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseService _warehouseService;

        public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
		public ObservableCollection<ProductModel> Items { get; } = new();

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


        public ReturnPurchaseListViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
        {
            Title = "Satın Alma İade İşlemleri";
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;
        }

        [RelayCommand]
        async Task GoToSharedProductList()
        {
            await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
            {
                ["ViewType"] = 6,
                ["Warehouse"] = Warehouse

            });
        }

        [RelayCommand]
        async Task GoToOperationForm()
        {

            if (Items.Any())
            {
                await Shell.Current.GoToAsync($"{nameof(ReturnPurchaseFormView)}", new Dictionary<string, object>
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

                bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.Name} ürün çıkartılacaktır. Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
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
                bool answer = await Shell.Current.DisplayAlert("Uyarı", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");

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
					["CurrentPage"] = "ReturnPurchaseListView"
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
