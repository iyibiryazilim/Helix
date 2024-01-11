using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
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
    public partial class ProductDetailSubUnitsetsAndBarcodeViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        ICustomQueryService _customQueryService;
        public ProductDetailSubUnitsetsAndBarcodeViewModel(IHttpClientService httpClientService, ICustomQueryService customQueryService)
        {
            Title = "Ölçü/Birim/Barkod";
            _httpClientService = httpClientService;
            _customQueryService = customQueryService;
            GetProductBarcodeCommand = new Command(async () => await LoadData());

        }
        public Command GetProductBarcodeCommand { get; }

        [ObservableProperty]
        Product product;

        public ObservableCollection<BarcodeAndSubUnitset> Items { get; set; } = new();
       

        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(1000);
			    await MainThread.InvokeOnMainThreadAsync(GetProductBarcodeAndUnitsetsAsync);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task GetProductBarcodeAndUnitsetsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var query = new ProductQuery().BarcodeAndSubUnitsetsByProductId(Product.ReferenceId);
                var result = await _customQueryService.GetObjectsAsync(httpClient,query);

                if (result.Data.Any())
                {
                    Items.Clear();
                    foreach (var item in result.Data)
                    {
                        var obj = Mapping.Mapper.Map<BarcodeAndSubUnitset>(item);
                        Items.Add(obj);
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
    }
}
