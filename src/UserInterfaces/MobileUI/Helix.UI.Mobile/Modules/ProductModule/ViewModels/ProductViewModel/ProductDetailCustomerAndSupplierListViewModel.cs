using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
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

    public partial class ProductDetailCustomerAndSupplierListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IProductService _productService;

        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        ProductCustomerAndSupplierOrderBy orderBy = ProductCustomerAndSupplierOrderBy.priorityasc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 20;

        [ObservableProperty]
        Product product;

        public ObservableCollection<ProductCustomerAndSupplier> Items { get; } = new();
        public Command GetCustomerAndSupplierCommand { get; }
        public Command<string> PerformSearchCommand { get; }

        public ProductDetailCustomerAndSupplierListViewModel(IHttpClientService httpClientService, IProductService productService)
        {
            Title = "Müşteri / Tedarikçi";
            _httpClientService = httpClientService;
            _productService = productService;
            GetCustomerAndSupplierCommand = new Command(async () => await LoadData());
            PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

        }
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
                await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task PerformSearchAsync(string text)
        {
            if (IsBusy) return;

            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.Length >= 3)
                    {
                        SearchText = text;
                        await ReloadAsync();
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
                await Shell.Current.DisplayAlert("Search Error:", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task LoadMoreAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage++;
                var result = await _productService.GetCustomerAndSupplier(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
                if (result.Data.Any())
                {
                    foreach (var item in result.Data)
                    {
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
                await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task ReloadAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _productService.GetCustomerAndSupplier(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

                if (result.Data.Any())
                {
                    Items.Clear();

                    foreach (var item in result.Data)
                    {
                        Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Reload Error:", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task SortAsync()
        {
            if (IsBusy) return;
            try
            {
                string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Kod A-Z", "Kod Z-A","Öncelik A-Z","Öncelik Z-A");
                if (!string.IsNullOrEmpty(response))
                {
                    CurrentPage = 0;
                    await Task.Delay(100);
                    switch (response)
                    {
                        case "Ad A-Z":
                            OrderBy = ProductCustomerAndSupplierOrderBy.nameasc;
                            await ReloadAsync();
                            break;
                        case "Ad Z-A":
                            OrderBy = ProductCustomerAndSupplierOrderBy.namedesc;
                            await ReloadAsync();
                            break;
                        case "Kod A-Z":
                            OrderBy = ProductCustomerAndSupplierOrderBy.codeasc;
                            await ReloadAsync();
                            break;
                        case "Kod Z-A":
                            OrderBy = ProductCustomerAndSupplierOrderBy.codedesc;
                            await ReloadAsync();
                            break;
                        case "Öncelik A-Z":
                            OrderBy = ProductCustomerAndSupplierOrderBy.priorityasc;
                            await ReloadAsync();
                            break;
                        case "Öncelik Z-A":
                            OrderBy = ProductCustomerAndSupplierOrderBy.prioritydesc;
                            await ReloadAsync();
                            break;
                        default:
                            await ReloadAsync();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Sort Warehouse Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
