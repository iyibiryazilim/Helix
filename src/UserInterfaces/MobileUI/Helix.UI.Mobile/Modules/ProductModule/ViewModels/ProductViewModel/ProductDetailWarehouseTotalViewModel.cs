using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]

public partial class ProductDetailWarehouseTotalViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IWarehouseTotalService _warehouseTotalService;


    [ObservableProperty]
    Product product;

    public ObservableCollection<WarehouseTotal> Items { get; } = new();
    public Command GetItemsCommand { get; }

    public Command PerformSearchCommand { get; }

    public ProductDetailWarehouseTotalViewModel(IHttpClientService httpClientService,IWarehouseTotalService warehouseTotalService)
    {
        Title = "Ambar Toplamları";
        _httpClientService = httpClientService;
        _warehouseTotalService = warehouseTotalService;

        GetItemsCommand = new Command(async () => await LoadData());
        PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));


    }
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 100;
    [ObservableProperty]
    bool includeWaiting = true;
    [ObservableProperty]
    WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.namedesc;

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
    public async Task SortAsync()
    {
        if (IsBusy) return;
        try
        {
            string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null,  "Miktara Göre Artan", "Miktara Göre Azalan","Kod A-Z", "Kod Z-A","Ad A-Z", "Ad Z-A", "Ambar Numarasına Göre Artan", "Ambar Numarasına Göre Azalan","Ambar Adı A-Z", "Ambar Adı Z-A");
            if (!string.IsNullOrEmpty(response))
            {
                CurrentPage = 0;
                await Task.Delay(100);
                switch (response)
                {
                    case "Miktara Göre Artan":
                        OrderBy = WarehouseTotalOrderBy.quantityasc;
                        await ReloadAsync();
                        break;
                    case "Miktara Göre Azalan":
                        OrderBy = WarehouseTotalOrderBy.quantitydesc;
                        await ReloadAsync();
                        break;
                    case "Numara A-Z":
                        OrderBy = WarehouseTotalOrderBy.warehousenumberasc;
                        await ReloadAsync();
                        break;
                    case "Numara Z-A":
                        OrderBy = WarehouseTotalOrderBy.warehousenamedesc;
                        await ReloadAsync();
                        break;
                    case "Ad A-Z":
                        OrderBy = WarehouseTotalOrderBy.nameasc;
                        await ReloadAsync();
                        break;
                    case "Ad Z-A":
                        OrderBy = WarehouseTotalOrderBy.namedesc;
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
            await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
            CurrentPage = 0;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _warehouseTotalService.GetWarehouseTotalByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

            if (result.Data.Any())
            {
                Items.Clear();
                foreach (var item in result.Data)
                {
                    await Task.Delay(100);
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
            var result = await _warehouseTotalService.GetWarehouseTotalByProductId(httpClient,Product.ReferenceId,SearchText, OrderBy, CurrentPage, PageSize);   
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
