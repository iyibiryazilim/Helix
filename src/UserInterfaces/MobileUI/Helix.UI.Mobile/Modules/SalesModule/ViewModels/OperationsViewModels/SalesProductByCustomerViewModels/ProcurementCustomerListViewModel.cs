﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

 public partial class ProcurementCustomerListViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    private readonly ICustomerService _customerService;
    //Lists
    public ObservableCollection<Current> Items { get; } = new();
    public ObservableCollection<Current> Results { get; } = new();

    //  [ObservableProperty]
    public ObservableCollection<Current> SelectedCustomers { get; } = new();


    [ObservableProperty]
    Current selectedCustomer;

    //Commands
    public Command GetCustomersCommand { get; }
    public Command SearchCommand { get; }

    //Properties
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    CustomerOrderBy orderBy = CustomerOrderBy.nameasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 5000;

   

    public ProcurementCustomerListViewModel(IHttpClientService httpClientService, ICustomerService customerService)
    {
        Title = "Müşteri Listesi";
        _httpClientService = httpClientService;
        _customerService = customerService;
        GetCustomersCommand = new Command(async () => await LoadData());
        SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

    }
    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            Items.Clear();

            await Task.Delay(500);
            await MainThread.InvokeOnMainThreadAsync(GetCustomersAsync);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;

        }
    }
    async Task GetCustomersAsync()
    {
        if (IsBusy)
            return;
        try
        {
            Items.Clear();
            Results.Clear();
            IsBusy = true;
            IsRefreshing = true;
            IsRefreshing = false;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _customerService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
            foreach (Current item in result.Data)
            {

                    Items.Add(item);
                    Results.Add(item);
                
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
                    Results.Clear();
                    foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText)))
                    {
                        Results.Add(item);
                    }
                }
            }
            else
            {
                SearchText = string.Empty;
                Results.Clear();
                foreach (var item in Items)
                {
                    Results.Add(item);
                }
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
    async Task ReloadAsync()
    {
        if (IsBusy)
            return;
        try
        {
            Items.Clear();
            Results.Clear();

            IsBusy = true;
            IsRefreshing = true;
            IsRefreshing = false;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _customerService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
            foreach (Current item in result.Data)
            {
                
                
                    Items.Add(item);
                    Results.Add(item);
                
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
        if (IsBusy) return;
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
                        Results.Clear();
                        foreach (var item in Items.OrderBy(x => x.Code).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Kod Z-A":
                        Results.Clear();
                        foreach (var item in Items.OrderByDescending(x => x.Code).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Ad A-Z":
                        Results.Clear();
                        foreach (var item in Items.OrderBy(x => x.Name).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Ad Z-A":
                        Results.Clear();
                        foreach (var item in Items.OrderByDescending(x => x.Name).ToList())
                        {
                            Results.Add(item);
                        }
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
            await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }


    //public void ToggleSelection(Current item)
    //{
    //    if (SelectedCustomers.Contains(item))
    //    {

    //        item.IsSelected = false;
    //        SelectedCustomers.Remove(item);
    //    }
    //    else
    //    {

    //        item.IsSelected = true;
    //        SelectedCustomers.Add(item);
    //    }
    //}



    [RelayCommand]
    private void ToggleSelection(Current item)
    {
        item.IsSelected = !item.IsSelected;
        if (SelectedCustomer != null)
        {
            SelectedCustomer.IsSelected = false;
        }
        if (item.IsSelected)
        {
            SelectedCustomers.Add(item);

        }



    }



    [RelayCommand]
    async Task GoToProcurementWarehouseSelectView()
    {
        if (SelectedCustomers.Any())
        {
            await Shell.Current.GoToAsync($"{nameof(ProcurementSelectWarehouseView)}", new Dictionary<string, object>
            {
                ["SelectedCustomers"] = SelectedCustomers
            });
        }
        else
        {
            await Shell.Current.DisplayAlert("Uyarı", "Bir sonraki sayfaya gitmek için Müşteri seçimi yapmanız gerekmektedir", "Tamam");

        }

    }






}
