using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using Org.Apache.Http.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel
{
    [QueryProperty(name: nameof(Product), queryId: nameof(Product))]

    public partial class ProductDetailWarehouseParametersViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseParameterService _wareHouseparameterService;


        [ObservableProperty]
        Product product;

        public ObservableCollection<WarehouseParameter> Items { get; } = new();
        public Command GetItemsCommand { get; }

        public Command PerformSearchCommand { get; }

        public ProductDetailWarehouseParametersViewModel(IHttpClientService httpClientService,IWarehouseParameterService warehouseParameterService)
        {
            Title = "Warehouse Parameter";
            _httpClientService = httpClientService;
            _wareHouseparameterService = warehouseParameterService;

            GetItemsCommand = new Command(async () => await LoadData());
            PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

        }

        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 10;
        [ObservableProperty]
        bool includeWaiting = true;
        [ObservableProperty]
        WarehouseParameterOrderBy orderBy = WarehouseParameterOrderBy.warehousenumberdesc;

        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(ReloadAsync);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task ReloadAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                CurrentPage = 0;
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var result = await _wareHouseparameterService.GetWarehouseParameterByProductId(httpClient, Product.ReferenceId, SearchText,OrderBy, CurrentPage, PageSize);

                if (result.Data.Any())
                {
                    Items.Clear();
                    foreach (var item in result.Data)
                    {
                        await Task.Delay(10);
                        Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task LoadMoreAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage++;
                var result = await _wareHouseparameterService.GetWarehouseParameterByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
                if (result.Data.Any())
                {
                    foreach (var item in result.Data)
                    {
                        await Task.Delay(100);
                        Items.Add(item);
                    }
                }
                else
                {
                    CurrentPage--;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Load More Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
        async Task PerformSearchAsync(string text)
        {
            if (IsBusy)
                return;
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.Length >= 3)
                    {
                        SearchText = text;
                        await LoadData();
                    }
                }
                else
                {
                    SearchText = string.Empty;
                    await ReloadAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
