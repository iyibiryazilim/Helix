using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using static Helix.UI.Mobile.Modules.SalesModule.DataStores.SalesOrderDataStore;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
    [QueryProperty(name: nameof(Product), queryId: nameof(Product))]
    [QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
    [QueryProperty(name: nameof(SelectedCustomers), queryId: nameof(SelectedCustomers))]


    public partial class ProcurementByCustomerViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        IWarehouseTotalService _warehouseTotalService;
        ISalesOrderLineService _salesOrderLineService;
        IServiceProvider _serviceProvider;


        public ObservableCollection<ProcurementCustomer> Items { get; } = new();

        // public ObservableCollection<ProcurementCustomerOrder> NonZeroPercentageOrders { get; set; } = new();

        public ObservableCollection<ProcurementCustomerOrder> Orders { get; set; } = new ObservableCollection<ProcurementCustomerOrder>();

        //müşteri sayfası
        [ObservableProperty]
        public ObservableCollection<Current> selectedCustomers;

        private List<WarehouseTotal> WarehouseTotals { get; set; } = new List<WarehouseTotal>();
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

        [ObservableProperty]
        ProcurementCustomer selectedProcurement;

        //model
        [ObservableProperty]
        ProcurementCustomerOrder procurementCustomerOrder;




        public ProcurementByCustomerViewModel(IHttpClientService httpClientService, ISalesOrderLineService salesOrderLineService, IWarehouseTotalService warehouseTotalService, IServiceProvider serviceProvider)
        {
            Title = "Hesaplanan Müşteri Listesi";
            _httpClientService = httpClientService;
            _salesOrderLineService = salesOrderLineService;
            _warehouseTotalService = warehouseTotalService;
            _serviceProvider = serviceProvider;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();



            LoadProcurementCustomerCommand = new Command(async () => await LoadProcurementCustomerAsync(cancellationTokenSource.Token));

        }

        async Task LoadProcurementCustomerAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (IsBusy) return;

                if (Items.Any())
                    Items.Clear();

                if (Warehouse != null)
                {

                    string selectedWarehouseName = Warehouse.Name;

                    Task warehouseTask = GetWarehouseTotalsAsync();
                    Task salesOrderTask = GetSalesOrdersAsync();

                    await Task.WhenAll(warehouseTask, salesOrderTask).WaitAsync(cancellationToken);

                    Debug.WriteLine($"WarehouseTotals Count: {WarehouseTotals.Count}");
                    Debug.WriteLine($"SalesOrders Count: {SalesOrders.Count}");


                    var groupingData = SalesOrders.Where(x => x.WaitingQuantity > 1).OrderByDescending(x => x.WaitingQuantity).GroupBy(x => x.CurrentCode);

                    List<ProcurementCustomer> CacheCustomer = new();

                    foreach (var item in groupingData)//müşteriler
                    {
                        ProcurementCustomer procurementCustomer = new ProcurementCustomer();
                        procurementCustomer.Customer = new Customer { Code = item.Key };

                        // Müşterinin bekleyen siparişlerini al
                        var customerSalesOrders = item.ToList();

                        foreach (var order in customerSalesOrders)//siparişler
                        {
                            procurementCustomer.Customer.Name = order.CurrentName;
                            procurementCustomer.Customer.ReferenceId = (int)order.CurrentReferenceId;
                            ProcurementCustomerOrder customerOrder = new ProcurementCustomerOrder();
                            customerOrder.SalesOrderLine = order;

                            //customerOrder.Customer.Code = order.CurrentCode;
                            //customerOrder.Customer.Name = order.CurrentName;
                            Debug.WriteLine($"SalesOrders - ProductReferenceId: {order.ProductReferenceId}");
                            // ambardaki stok miktarı
                            var warehouseTotal = WarehouseTotals.FirstOrDefault(wt => wt.ProductReferenceId == order.ProductReferenceId);
                            if (warehouseTotal != null)
                            {
                                double onHand = warehouseTotal.OnHand;
                                Debug.WriteLine($"On Hand for ProductReferenceId: {order.ProductReferenceId} - {onHand}");

                                double waitingQuantity = order.WaitingQuantity ?? 0;
                                Debug.WriteLine($"Waiting Quantity for ProductReferenceId: {order.ProductReferenceId} - {waitingQuantity}");

                                // Karşılanan miktar yüzde olarak hesaplanıyor
                                double matchingPercentage = (onHand >= waitingQuantity) ? 100: (onHand /waitingQuantity) * 100 ;
                                Debug.WriteLine($"Matching Percentage for ProductReferenceId: {order.ProductReferenceId} - {matchingPercentage}%");

                               

                                //customerOrder.ProcurementQuantity = matchingPercentage;
                                customerOrder.ProcurementRate = matchingPercentage;

                                // Bekleyen miktarı stoktan eksilt
                                if (onHand >= waitingQuantity)
                                {
                                    warehouseTotal.OnHand -= waitingQuantity;
                                }


                            }

                            procurementCustomer.Orders.Add(customerOrder);

                        }

                        CacheCustomer.Add(procurementCustomer);

                    }


                    foreach (var procurementCustomer in CacheCustomer)
                    {
                        if (procurementCustomer.Orders.Any())
                            procurementCustomer.ProcurementRate = procurementCustomer.Orders.Average(x => x.ProcurementRate);
                    }



                    foreach (var procurementCustomer in CacheCustomer)
                    {
                        Items.Add(procurementCustomer);
                    }


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


        [RelayCommand]
        public async Task OpenProcurementBottomSheetAsync(ProcurementCustomer procurementCustomer)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                ProcurementBottomSheetViewModel viewModel = _serviceProvider.GetService<ProcurementBottomSheetViewModel>();
                viewModel.SelectedProcurementCustomer = procurementCustomer;

                ProcurementBottomSheetView sheet = new ProcurementBottomSheetView(viewModel);


                await sheet.ShowAsync();
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

        [RelayCommand]
        async Task GoToNextAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineLineListView)}", new Dictionary<string, object>
                {
                    ["Warehouse"] = Warehouse,
                    ["Current"] = SelectedProcurement.Customer
                });

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Procurement  Error", ex.Message, "Tamam");
            }
        }

        async Task GetWarehouseTotalsAsync()
        {
            try
            {
                WarehouseTotals.Clear();
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                var Result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, WarehouseOrderBy, CurrentPage, PageSize);


                Debug.WriteLine($"WarehouseTotal Service Result: {Result}");

                foreach (var item in Result.Data)
                {
                    WarehouseTotals.Add(item);
                }


                Debug.WriteLine($"WarehouseTotals Count: {WarehouseTotals.Count}");

                foreach (var wt in WarehouseTotals)
                {
                    Debug.WriteLine($"ProductReferenceId: {wt.ProductReferenceId}, OnHand: {wt.OnHand}");
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

                    foreach (Current current in SelectedCustomers)
                    {
                        var Result = await _salesOrderLineService.GetObjectsByCurrentIdAndWarehouseNumber(httpClient, current.ReferenceId, Warehouse.Number, true, SearchText, SalesOrderBy, CurrentPage, PageSize);
                        foreach (var item in Result.Data)
                        {
                            SalesOrders.Add(item);
                        }

                    }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Sales Order Error", ex.Message, "Tamam");
            }
        }



        [RelayCommand]
        private void ToggleSelection(ProcurementCustomer item)
        {
            item.IsSelected = !item.IsSelected;
            if (SelectedProcurement != null)
            {
                SelectedProcurement.IsSelected = false;
            }
            if (item.IsSelected)
            {
                SelectedProcurement = item;
            }
        }




    }
}
