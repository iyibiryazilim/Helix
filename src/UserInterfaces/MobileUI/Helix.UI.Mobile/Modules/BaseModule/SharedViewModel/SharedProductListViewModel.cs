﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;

using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

public partial class SharedProductListViewModel :BaseViewModel
{
    IHttpClientService _httpClientService;
    private readonly IProductService _productService;

    public ObservableCollection<Product> Items { get; } = new();

    public Command SearchCommand { get; }
    //Properties
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    ProductOrderBy orderBy = ProductOrderBy.nameasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 20;
    [ObservableProperty]
    string groupCode = string.Empty;

    public Command GetProductsCommand { get; }
    public SharedProductListViewModel( IHttpClientService httpClientService, IProductService productService)
    {

        Title = "Ürün Listesi";
        _httpClientService = httpClientService;
        _productService = productService;
        GetProductsCommand = new Command(async () => await LoadData());
        SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
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
            await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task PerformSearchAsync(string text)
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
        }
        finally
        {
            IsBusy = false;
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
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            CurrentPage++;
            var result = await _productService.GetObjects(httpClient, SearchText, GroupCode, OrderBy, CurrentPage, PageSize);
            if (result.Data.Any())
            {
                foreach (Product item in result.Data)
                {
                    await Task.Delay(50);
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
            await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");

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
        if (IsBusy)
            return;


        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            CurrentPage = 0;
            var result = await _productService.GetObjects(httpClient, SearchText, GroupCode, OrderBy, CurrentPage, PageSize);
            if (result.Data.Any())
            {
                Items.Clear();
                foreach (Product item in result.Data)
                {
                    await Task.Delay(100);
                    Items.Add(item);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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
        
        try
        {
            string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
            if (!string.IsNullOrEmpty(response))
            {
                CurrentPage = 0;
                await Task.Delay(100);
                switch (response)
                {
                    case "Kod A-Z":
                        OrderBy = ProductOrderBy.codeasc;
                        await ReloadAsync();
                        break;
                    case "Kod Z-A":
                        OrderBy = ProductOrderBy.codedesc;
                        await ReloadAsync();
                        break;
                    case "Ad A-Z":
                        OrderBy = ProductOrderBy.nameasc;
                        await ReloadAsync();
                        break;
                    case "Ad Z-A":
                        OrderBy = ProductOrderBy.namedesc;
                        await ReloadAsync();
                        break;
                    default:
                        await Shell.Current.DisplayAlert("Customer Error: ", "Yanlış Girdi", "Tamam");
                        await ReloadAsync();
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }




}