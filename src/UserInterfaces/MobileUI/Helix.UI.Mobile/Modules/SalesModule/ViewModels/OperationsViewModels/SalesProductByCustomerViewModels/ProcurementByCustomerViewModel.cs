using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.SalesModule.DataStores.SalesOrderDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
    public partial class ProcurementByCustomerViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseTotalService _warehouseTotalService;
        ISalesOrderLineService _salesOrderLineService;


        public ObservableCollection<ProcurementCustomer> Items { get; } = new();

        private List<WarehouseTotal> WarehouseTotals { get; set; } = new();
        private List<SalesOrderLine> SalesOrders { get; set; } = new();

        public Command LoadProcurementCustomerCommand { get; }

        //Properties
        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        WarehouseTotalOrderBy warehouseOrderBy = WarehouseTotalOrderBy.nameasc;
        [ObservableProperty]
        SalesOrdersLineOrderBy salesOrderBy = SalesOrdersLineOrderBy.duedatedesc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 100000;
        [ObservableProperty]
        Warehouse warehouse;




        public ProcurementByCustomerViewModel(IHttpClientService httpClientService,ISalesOrderLineService salesOrderLineService,IWarehouseTotalService warehouseTotalService)
        {
            Title = "Hesaplanan Müşteri Listesi";
            _httpClientService = httpClientService;
            _salesOrderLineService = salesOrderLineService;
            _warehouseTotalService = warehouseTotalService;
            CancellationTokenSource cancellationTokenSource=new CancellationTokenSource();
            
            LoadProcurementCustomerCommand = new Command(async () =>await LoadProcurementCustomerAsync(cancellationTokenSource.Token));

        }

        async Task LoadProcurementCustomerAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (IsBusy) return;

                if (Items.Any())
                    Items.Clear();


                Task warehouseTask = GetWarehouseTotalsAsync();

                Task salesOrderTask = GetSalesOrdersAsync();

                await Task.WhenAll(warehouseTask, salesOrderTask).WaitAsync(cancellationToken);

                var groupingData = SalesOrders.GroupBy(x => x.CurrentCode);

                foreach (var item in groupingData)//müşteriler
                {
                    ProcurementCustomer procurementCustomer = new ProcurementCustomer();
                    procurementCustomer.Customer = new Customer { Code = item.Key };

                    foreach (var order in item.ToList())//siparişler
                    {
                        ProcurementCustomerOrder customerOrder = new ProcurementCustomerOrder();
                        customerOrder.SalesOrderLine = order;
                        //miktar hesaplaacak bölüm

                        procurementCustomer.Orders.Add(customerOrder);
                    }
                    Items.Add(procurementCustomer);
                }
              



            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Procurement Customer Error", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task GetWarehouseTotalsAsync()
        {
            try
            {
                if (Items.Any())
                    Items.Clear();
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var Result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, WarehouseOrderBy, CurrentPage, PageSize);
                foreach (var item in Result.Data)
                {
                    WarehouseTotals.Add(item);

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Warehouse Total Error", ex.Message, "Tamam");
            }
        }

        async Task GetSalesOrdersAsync()
        {
            try
            {
                if (Items.Any())
                    Items.Clear();
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var Result = await _salesOrderLineService.GetObjects(httpClient,true, SearchText, SalesOrderBy, CurrentPage, PageSize);
                foreach ( var item in Result.Data)
                {
                    SalesOrders.Add(item);
                }


            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Sales Order Error", ex.Message, "Tamam");
            }
        }



    }
}
