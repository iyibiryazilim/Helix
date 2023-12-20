using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

public partial class ProductListViewModel :BaseViewModel
{
    IHttpClientService _httpClientService;
    private readonly IProductService _productService;
    //private readonly IEndProductService _endProductService;

    public ObservableCollection<Product> Items { get; } = new();
    public ObservableCollection<string> Groups { get; } = new();


    public Command GetProductsCommand { get;  }

    public ProductListViewModel(IHttpClientService httpClientService, IProductService productService)
    {
        Title = "Malzemeler";
        _httpClientService = httpClientService;
        _productService = productService;
        GetProductsCommand = new Command(async () => await LoadData());

    }

    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            await Task.Delay(500);
            await MainThread.InvokeOnMainThreadAsync(GetProductsAsync);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }





    async Task GetProductsAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var result = await _productService.GetObjects(httpClient);

            if (result.Data.Any())
            {
                Groups.Clear();
                var groupingData= result.Data.GroupBy(x => x.GroupName);
                Groups.Add("Tümü");
                foreach (var group in groupingData)
                {
                    Groups.Add(group.Key);
                }
                
                Items.Clear();
                foreach (Product item in result.Data)
                {
                    Items.Add(item);
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
