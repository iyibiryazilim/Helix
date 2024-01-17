using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels
{
    public partial class ReturnSalesSelectWarehouseViewModel:BaseViewModel
    {
         IHttpClientService _httpClientService;
    private readonly IWarehouseService _warehouseService;
    ICustomQueryService _customQueryService;

    //Lists
    public ObservableCollection<Warehouse> Items { get; } = new();
    public ObservableCollection<Warehouse> Results { get; } = new();

    //Commands
    public Command GetWarehousesCommand { get; }
    public Command SearchCommand { get; }

    //Properties
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    WarehouseOrderBy orderBy = WarehouseOrderBy.numberasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 1000;

    [ObservableProperty]
    Warehouse selectedWarehouse;

    [ObservableProperty]
    Product product;



    public ReturnSalesSelectWarehouseViewModel(IHttpClientService httpClientService,IWarehouseService warehouseService,ICustomQueryService customQueryService)
    {
        Title = "Ambar Listesi";
        _httpClientService = httpClientService;
        _warehouseService = warehouseService;
        _customQueryService = customQueryService;
        GetWarehousesCommand = new Command(async () => await LoadData());
        SearchCommand = new Command<string>(async (searchText) => await
        PerformSearchAsync(searchText));

    }

    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            await Task.Delay(500);
            await MainThread.InvokeOnMainThreadAsync(GetWarehousesAsync);

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
    async Task GetWarehousesAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();


            var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
            foreach (Warehouse item in result.Data)
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
                    foreach (var item in Items.ToList().Where(x => x.Name.Contains(SearchText) || x.LastTransactionDate.ToString().Contains(SearchText)))
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
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
            foreach (Warehouse item in result.Data)
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
            string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Numara A-Z", "Numara Z-A", "Ad A-Z", "Ad Z-A");
            if (!string.IsNullOrEmpty(response))
            {
                CurrentPage = 0;
                await Task.Delay(100);
                switch (response)
                {
                    case "Numara A-Z":
                        Results.Clear();
                        foreach (var item in Items.OrderBy(x => x.Number).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Numara Z-A":
                        Results.Clear();
                        foreach (var item in Items.OrderByDescending(x => x.Number).ToList())
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

    [RelayCommand]
    async Task GoToTransaction()
    {
        if (SelectedWarehouse == null)
        {
            await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Ambar seçimi yapmanız gerekmektedir", "Tamam");
        }
        else
       {
           await Shell.Current.GoToAsync($"{nameof(ReturnSalesListView)}", new Dictionary<string, object>
            {
               ["Warehouse"] = SelectedWarehouse
           });
       }

    }

    [RelayCommand]
    private void ToggleSelection(Warehouse item)
    {
        item.IsSelected = !item.IsSelected;
        if (SelectedWarehouse != null)
        {
            SelectedWarehouse.IsSelected = false;
        }
        if (item.IsSelected)
        {
            SelectedWarehouse = item;
        }
    }


    }
}
