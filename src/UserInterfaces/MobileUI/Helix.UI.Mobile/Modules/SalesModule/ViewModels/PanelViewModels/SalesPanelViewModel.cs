using AutoMapper;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.PanelModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels

{
    public partial class SalesPanelViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        ICustomQueryService _customQueryService;

        public ObservableCollection<Customer> Customers { get; } = new();
        public ObservableCollection<CustomerTransactionLine> Lines { get; } = new();

        public SalesPanelModel salesPanelModel { get; set; }


        public Command GetDataCommand { get; }

        public SalesPanelViewModel(ICustomQueryService customQueryService, IHttpClientService httpClientService)
        {
            _customQueryService = customQueryService;
            _httpClientService = httpClientService;
            salesPanelModel = new SalesPanelModel();
            GetDataCommand = new Command(async () => await LoadData());


        }
        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                
                await Task.Delay(500);
                await Task.WhenAll(GetTopCustomersAsync(), GetLastTransactionsAsync(), GetSalesDispatchCountAsync(), GetPurchaseCountAsync());


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
        async Task GetTopCustomersAsync()
        {
            try
            {
                IsBusy = true;
                Customers.Clear();
                var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new CustomerQuery().GetTopCustomers());
                foreach (var item in result.Data)
                {
                    await Task.Delay(50);
                    var obj = Mapping.Mapper.Map<Customer>(item);
                    if (obj.Image == "{}")
                    {
                        obj.Image = null;
                    }
                    Customers.Add(obj);
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
            }

        }

        async Task GetLastTransactionsAsync()
        {
            try
            {
                IsBusy = true;
                Lines.Clear();
                var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new CustomerQuery().GetLastSaleLines());
                foreach (var item in result.Data)
                {
                    await Task.Delay(50);
                    var obj = Mapping.Mapper.Map<CustomerTransactionLine>(item);
                    Lines.Add(obj);
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
            }

        }

        [RelayCommand]
        async Task GoToDetailAsync(Customer current)
        {
            try
            {
                await Task.Delay(500);
                await Shell.Current.GoToAsync($"{nameof(CustomerDetailView)}", new Dictionary<string, object>
                {
                    [nameof(Current)] = current
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
            }
        }

        async Task GetSalesDispatchCountAsync()
        {
            try
            {
               
                IsBusy = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var result = await _customQueryService.GetObjectsAsync(httpClient,new SalesPanelQuery().GetSalesCountAsync());
                if (result.Data.Any())
                {
                    foreach(var item in result.Data)
                    {
                        var obj = Mapping.Mapper.Map<SalesPanelModel>(item);
                        salesPanelModel.SalesDispatchCount = obj.SalesDispatchCount;
                    }

                }

              

            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }


        async Task GetPurchaseCountAsync()
        {
            try
            {
                IsBusy = true;

                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var result = await _customQueryService.GetObjectsAsync(httpClient, new SalesPanelQuery().GetPurchaseCountAsync());

                if (result.Data.Any())
                {
                    foreach(var item in result.Data)
                    {
                        var obj = Mapping.Mapper.Map<SalesPanelModel>(item);
                        salesPanelModel.PurchaseReturnCount = obj.PurchaseReturnCount;
                    }
                }

            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
