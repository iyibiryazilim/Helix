using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
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

    public partial class ProductDetailAlternativeProductListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IProductService _productService;

        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        ProductOrderBy orderBy = ProductOrderBy.nameasc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 20;

        [ObservableProperty]
        Product product ;

        public ObservableCollection<Product> Items { get; } = new();
        public Command GetAlternativeProductsCommand { get; }
        public Command<string> PerformSearchCommand { get; }

        public ProductDetailAlternativeProductListViewModel(IHttpClientService httpClientService, IProductService productService)
        {
            Title = "Alternatif Malzemeler";
            _httpClientService = httpClientService;
            _productService = productService;
            GetAlternativeProductsCommand = new Command(async () => await LoadData());
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
                var result = await _productService.GetAlternativeProducts(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
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
                var result = await _productService.GetAlternativeProducts(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

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
                string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Kod A-Z", "Kod Z-A");
                if (!string.IsNullOrEmpty(response))
                {
                    CurrentPage = 0;
                    await Task.Delay(100);
                    switch (response)
                    {
                        case "Ad A-Z":
                            OrderBy = ProductOrderBy.nameasc;
                            await ReloadAsync();
                            break;
                        case "Ad Z-A":
                            OrderBy = ProductOrderBy.namedesc;
                            await ReloadAsync();
                            break;
                        case "Kod A-Z":
                            OrderBy = ProductOrderBy.codeasc;
                            await ReloadAsync();
                            break;
                        case "Kod Z-A":
                            OrderBy = ProductOrderBy.codedesc;
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

        [RelayCommand]
        async Task GoToDetailAsync(Product product)
        {
            try
            {
                await Task.Delay(500);
                await Shell.Current.GoToAsync($"{nameof(ProductDetailView)}", new Dictionary<string, object>
                {
                    ["Product"] = product
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
            }
        }
    }
}
