using Android.Graphics;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.BaseModule.Views;
using Helix.UI.Mobile.Modules.BaseModule.Views.Current;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.ViewModels;
using Helix.UI.Mobile.Modules.LoginModule.Views.BottomSheetViews;
using Helix.UI.Mobile.Modules.PanelModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Panel;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Plugin.LocalNotification;



namespace Helix.UI.Mobile;

public partial class AppShell : Shell
{
    private readonly TimeSpan interval = TimeSpan.FromSeconds(15);
    private System.Threading.Timer timer;
    public AppShell()
    {

        InitializeComponent();

        StartTimer();

        var serviceProvider = IPlatformApplication.Current.Services;
        using (var scope = serviceProvider.CreateScope())
        {
            var serviceProviderScoped = scope.ServiceProvider;
            var viewModel = serviceProviderScoped.GetRequiredService<LoginViewModel>();
            BindingContext = viewModel;
        }

        Routing.RegisterRoute(nameof(ProductListView), typeof(ProductListView));
        Routing.RegisterRoute(nameof(ProductDetailView), typeof(ProductDetailView));
        Routing.RegisterRoute(nameof(WarehouseDetailView), typeof(WarehouseDetailView));
        Routing.RegisterRoute(nameof(CustomerDetailView), typeof(CustomerDetailView));
        Routing.RegisterRoute(nameof(ProductionTransactionOperationView), typeof(ProductionTransactionOperationView));
        Routing.RegisterRoute(nameof(WarehouseDetailInputTransactionView), typeof(WarehouseDetailInputTransactionView));
        Routing.RegisterRoute(nameof(WarehouseDetailOutputTransactionView), typeof(WarehouseDetailOutputTransactionView));
        Routing.RegisterRoute(nameof(WarehouseDetailProductListView), typeof(WarehouseDetailProductListView));
        Routing.RegisterRoute(nameof(ProductDetailInputReturnListView), typeof(ProductDetailInputReturnListView));
        Routing.RegisterRoute(nameof(ProductDetailInputTransactionListView), typeof(ProductDetailInputTransactionListView));
        Routing.RegisterRoute(nameof(ProductDetailOutputReturnListView), typeof(ProductDetailOutputReturnListView));
        Routing.RegisterRoute(nameof(ProductDetailOutputTransactionListView), typeof(ProductDetailOutputTransactionListView));
        Routing.RegisterRoute(nameof(ProductDetailPurchaseDispatchListView), typeof(ProductDetailPurchaseDispatchListView));
        Routing.RegisterRoute(nameof(ProductDetailPurchaseOrderListView), typeof(ProductDetailPurchaseOrderListView));
        Routing.RegisterRoute(nameof(ProductDetailSalesDispatchListView), typeof(ProductDetailSalesDispatchListView));
        Routing.RegisterRoute(nameof(ProductDetailSalesOrderListView), typeof(ProductDetailSalesOrderListView));
        Routing.RegisterRoute(nameof(InCountingTransactionOperationView), typeof(InCountingTransactionOperationView));
        Routing.RegisterRoute(nameof(OutCountingTransactionOperationView), typeof(OutCountingTransactionOperationView));
        Routing.RegisterRoute(nameof(ConsumableTransactionOperationView), typeof(ConsumableTransactionOperationView));
        Routing.RegisterRoute(nameof(WastageTransactionOperationView), typeof(WastageTransactionOperationView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderCustomerView), typeof(DispatchBySalesOrderCustomerView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderFicheView), typeof(DispatchBySalesOrderFicheView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineListView), typeof(DispatchBySalesOrderLineListView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderSummaryView), typeof(DispatchBySalesOrderSummaryView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderFormView), typeof(DispatchBySalesOrderFormView));
        Routing.RegisterRoute(nameof(WarehouseDetailInputTransactionView), typeof(WarehouseDetailInputTransactionView));
        Routing.RegisterRoute(nameof(WarehouseDetailOutputTransactionView), typeof(WarehouseDetailOutputTransactionView));
        Routing.RegisterRoute(nameof(WarehouseDetailProductListView), typeof(WarehouseDetailProductListView));
        Routing.RegisterRoute(nameof(CustomerFastOperationBottomSheetView), typeof(CustomerFastOperationBottomSheetView));
        Routing.RegisterRoute(nameof(SharedProductListView), typeof(SharedProductListView));
        Routing.RegisterRoute(nameof(CurrentShowMoreBottomSheetView), typeof(CurrentShowMoreBottomSheetView));
        Routing.RegisterRoute(nameof(CurrentInputListView), typeof(CurrentInputListView));
        Routing.RegisterRoute(nameof(CurrentOutputListView), typeof(CurrentOutputListView));
        Routing.RegisterRoute(nameof(CurrentPurchaseDispatchListView), typeof(CurrentPurchaseDispatchListView));
        Routing.RegisterRoute(nameof(CurrentSalesDispatchListView), typeof(CurrentSalesDispatchListView));
        Routing.RegisterRoute(nameof(CurrentPurchaseOrderListView), typeof(CurrentPurchaseOrderListView));
        Routing.RegisterRoute(nameof(CurrentSalesOrderListView), typeof(CurrentSalesOrderListView));
        Routing.RegisterRoute(nameof(CurrentPurchaseReturnListView), typeof(CurrentPurchaseReturnListView));
        Routing.RegisterRoute(nameof(CurrentSalesReturnListView), typeof(CurrentSalesReturnListView));
        Routing.RegisterRoute(nameof(SupplierDetailView), typeof(SupplierDetailView));
        Routing.RegisterRoute(nameof(SuccessPageView), typeof(SuccessPageView));
        Routing.RegisterRoute(nameof(FailedPageView), typeof(FailedPageView));
        Routing.RegisterRoute(nameof(ConsumableTransactionOperationFormView), typeof(ConsumableTransactionOperationFormView));
        Routing.RegisterRoute(nameof(ProductTransactionOperationFormContentView), typeof(ProductTransactionOperationFormContentView));
        Routing.RegisterRoute(nameof(ProductionTransactionOperationFormView), typeof(ProductionTransactionOperationFormView));
        Routing.RegisterRoute(nameof(InCountingTransactionOperationFormView), typeof(InCountingTransactionOperationFormView));
        Routing.RegisterRoute(nameof(OutCountingTransactionOperationFormView), typeof(OutCountingTransactionOperationFormView));
        Routing.RegisterRoute(nameof(WastageTransactionOperationFormView), typeof(WastageTransactionOperationFormView));
        Routing.RegisterRoute(nameof(SalesDispatchListView), typeof(SalesDispatchListView));
        Routing.RegisterRoute(nameof(SalesDispatchFormView), typeof(SalesDispatchFormView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderSupplierView), typeof(DispatchByPurchaseOrderSupplierView));
        Routing.RegisterRoute(nameof(PurchaseDispatchListView), typeof(PurchaseDispatchListView));
        Routing.RegisterRoute(nameof(PurchaseDispatchFormView), typeof(PurchaseDispatchFormView));
        Routing.RegisterRoute(nameof(SuccessPageView), typeof(SuccessPageView));
        Routing.RegisterRoute(nameof(FailedPageView), typeof(FailedPageView));
        Routing.RegisterRoute(nameof(ConsumableTransactionOperationFormView), typeof(ConsumableTransactionOperationFormView));
        Routing.RegisterRoute(nameof(ProductTransactionOperationFormContentView), typeof(ProductTransactionOperationFormContentView));
        Routing.RegisterRoute(nameof(ProductionTransactionOperationFormView), typeof(ProductionTransactionOperationFormView));
        Routing.RegisterRoute(nameof(InCountingTransactionOperationFormView), typeof(InCountingTransactionOperationFormView));
        Routing.RegisterRoute(nameof(OutCountingTransactionOperationFormView), typeof(OutCountingTransactionOperationFormView));
        Routing.RegisterRoute(nameof(WastageTransactionOperationFormView), typeof(WastageTransactionOperationFormView));
        Routing.RegisterRoute(nameof(SalesDispatchListView), typeof(SalesDispatchListView));
        Routing.RegisterRoute(nameof(SalesDispatchFormView), typeof(SalesDispatchFormView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderSupplierView), typeof(DispatchByPurchaseOrderSupplierView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderFicheView), typeof(DispatchByPurchaseOrderFicheView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderFormView), typeof(DispatchByPurchaseOrderFormView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineListView), typeof(DispatchByPurchaseOrderLineListView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderSummaryView), typeof(DispatchByPurchaseOrderSummaryView));
        Routing.RegisterRoute(nameof(WarehouseTransactionContentView), typeof(WarehouseTransactionContentView));
        Routing.RegisterRoute(nameof(SalesOrderLineContentView), typeof(SalesOrderLineContentView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineLineListView), typeof(DispatchByPurchaseOrderLineLineListView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineSupplierView), typeof(DispatchByPurchaseOrderLineSupplierView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineCustomerView), typeof(DispatchBySalesOrderLineCustomerView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineLineListView), typeof(DispatchBySalesOrderLineLineListView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineFormView), typeof(DispatchBySalesOrderLineFormView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineSummaryView), typeof(DispatchBySalesOrderLineSummaryView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineSummaryView), typeof(DispatchByPurchaseOrderLineSummaryView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderSelectedLineListView), typeof(DispatchBySalesOrderSelectedLineListView));
        Routing.RegisterRoute(nameof(ProductDetailWaitingOrderLineContentView), typeof(ProductDetailWaitingOrderLineContentView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationView), typeof(WarehouseTransferOperationView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineSelectedLineListView), typeof(DispatchBySalesOrderLineSelectedLineListView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationSelectedItemsListView), typeof(WarehouseTransferOperationSelectedItemsListView));
        Routing.RegisterRoute(nameof(ConsumableTransactionOperationSelectWarehouseView), typeof(ConsumableTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineFormView), typeof(DispatchByPurchaseOrderLineFormView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationFormView), typeof(WarehouseTransferOperationFormView));
        Routing.RegisterRoute(nameof(SupplierFastOperationBottomSheetView), typeof(SupplierFastOperationBottomSheetView));
        Routing.RegisterRoute(nameof(ReturnPanelView), typeof(ReturnPanelView));
        Routing.RegisterRoute(nameof(ReturnPurchasesView), typeof(ReturnPurchasesView));
        Routing.RegisterRoute(nameof(ReturnSalesView), typeof(ReturnSalesView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionCustomerView), typeof(ReturnBySalesDispatchTransactionCustomerView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineCustomerView), typeof(ReturnBySalesDispatchTransactionLineCustomerView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionCustomerView), typeof(ReturnBySalesDispatchTransactionCustomerView));
        Routing.RegisterRoute(nameof(ConsumableTransactionOperationSelectWarehouseView), typeof(ConsumableTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineFormView), typeof(DispatchByPurchaseOrderLineFormView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationWarehouseListView), typeof(WarehouseTransferOperationWarehouseListView));
        Routing.RegisterRoute(nameof(SupplierFastOperationBottomSheetView), typeof(SupplierFastOperationBottomSheetView));
        Routing.RegisterRoute(nameof(ProductDetailWarehouseTotalView), typeof(ProductDetailWarehouseTotalView));
        Routing.RegisterRoute(nameof(ProductDetailWarehouseParametersView), typeof(ProductDetailWarehouseParametersView));
        Routing.RegisterRoute(nameof(ProductDetailSubUnitsetsAndBarcodeView), typeof(ProductDetailSubUnitsetsAndBarcodeView));
        Routing.RegisterRoute(nameof(InCountingTransactionOperationSelectWarehouseView), typeof(InCountingTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(OutCountingTransactionOperationSelectWarehouseView), typeof(OutCountingTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(ProductionTransactionOperationSelectWarehouseView), typeof(ProductionTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(WastageTransactionOperationSelectWarehouseView), typeof(WastageTransactionOperationSelectWarehouseView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionSupplierView), typeof(ReturnByPurchaseDispatchTransactionSupplierView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationTransferredWarehouseListView), typeof(WarehouseTransferOperationTransferredWarehouseListView));
        Routing.RegisterRoute(nameof(WarehouseTransferOperationSummaryView), typeof(WarehouseTransferOperationSummaryView));
        Routing.RegisterRoute(nameof(ExitProductSelectView), typeof(ExitProductSelectView));
        Routing.RegisterRoute(nameof(ChangeProductView), typeof(ChangeProductView));
        Routing.RegisterRoute(nameof(ExitWarehouseSelectView), typeof(ExitWarehouseSelectView));
        Routing.RegisterRoute(nameof(TransferTransactionSummaryView), typeof(TransferTransactionSummaryView));
        Routing.RegisterRoute(nameof(ProductDetailAlternativeProductListView), typeof(ProductDetailAlternativeProductListView));
        Routing.RegisterRoute(nameof(ProductDetailCustomerAndSupplierListView), typeof(ProductDetailCustomerAndSupplierListView));
        Routing.RegisterRoute(nameof(EntryWarehouseSelectView), typeof(EntryWarehouseSelectView));
        Routing.RegisterRoute(nameof(SalesDispatchWarehouseListView), typeof(SalesDispatchWarehouseListView));
        Routing.RegisterRoute(nameof(EntryProductSelectView), typeof(EntryProductSelectView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderWarehouseListView), typeof(DispatchBySalesOrderWarehouseListView));
        Routing.RegisterRoute(nameof(WarehouseCountingSelectWarehouseView), typeof(WarehouseCountingSelectWarehouseView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineWarehouseListView), typeof(DispatchBySalesOrderLineWarehouseListView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderWarehouseListView), typeof(DispatchByPurchaseOrderWarehouseListView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineWarehouseListView), typeof(DispatchByPurchaseOrderLineWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnPurchaseSelectWarehouseView), typeof(ReturnPurchaseSelectWarehouseView));
        Routing.RegisterRoute(nameof(ReturnSalesSelectWarehouseView), typeof(ReturnSalesSelectWarehouseView));
        Routing.RegisterRoute(nameof(ReturnSalesListView), typeof(ReturnSalesListView));
        Routing.RegisterRoute(nameof(ReturnPurchaseListView), typeof(ReturnPurchaseListView));
        Routing.RegisterRoute(nameof(ReturnSalesFormView), typeof(ReturnSalesFormView));
        Routing.RegisterRoute(nameof(WarehouseCountingListView), typeof(WarehouseCountingListView));
        Routing.RegisterRoute(nameof(WarehouseCountingSummaryView), typeof(WarehouseCountingSummaryView));
        Routing.RegisterRoute(nameof(AllProductsListSharedView), typeof(AllProductsListSharedView));
        Routing.RegisterRoute(nameof(WarehouseCountingSelectProductsView), typeof(WarehouseCountingSelectProductsView));
        Routing.RegisterRoute(nameof(PurchaseDispatchSelectWarehouseView), typeof(PurchaseDispatchSelectWarehouseView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderShipInfoListView), typeof(DispatchBySalesOrderShipInfoListView));
        Routing.RegisterRoute(nameof(DispatchBySalesOrderLineShipInfoListView), typeof(DispatchBySalesOrderLineShipInfoListView));
        Routing.RegisterRoute(nameof(ReturnSalesFormView), typeof(ReturnSalesFormView));
        Routing.RegisterRoute(nameof(ReturnPurchaseFormView), typeof(ReturnPurchaseFormView));
        Routing.RegisterRoute(nameof(SalesProductByCustomerListView), typeof(SalesProductByCustomerListView));
        Routing.RegisterRoute(nameof(ProcurementOptionView), typeof(ProcurementOptionView));
        Routing.RegisterRoute(nameof(ProcurementByCustomerView), typeof(ProcurementByCustomerView));
        Routing.RegisterRoute(nameof(ProcurementByProductView), typeof(ProcurementByProductView));
        Routing.RegisterRoute(nameof(ProcurementSelectWarehouseView), typeof(ProcurementSelectWarehouseView));
        Routing.RegisterRoute(nameof(ProcurementBottomSheetView), typeof(ProcurementBottomSheetView));
        Routing.RegisterRoute(nameof(ProcurementCustomerListView), typeof(ProcurementCustomerListView));
        Routing.RegisterRoute(nameof(SalesProductView), typeof(SalesProductView));
        Routing.RegisterRoute(nameof(SalesProductByCustomerListView), typeof(SalesProductByCustomerListView));
        Routing.RegisterRoute(nameof(ProcurementOptionView), typeof(ProcurementOptionView));
        Routing.RegisterRoute(nameof(ProcurementByCustomerView), typeof(ProcurementByCustomerView));
        Routing.RegisterRoute(nameof(ProcurementByProductView), typeof(ProcurementByProductView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionShipInfoListView), typeof(ReturnByPurchaseDispatchTransactionShipInfoListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionWarehouseListView), typeof(ReturnByPurchaseDispatchTransactionWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionFicheView), typeof(ReturnByPurchaseDispatchTransactionFicheView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineListView), typeof(ReturnByPurchaseDispatchTransactionLineListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionSummaryView), typeof(ReturnByPurchaseDispatchTransactionSummaryView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionFormView), typeof(ReturnByPurchaseDispatchTransactionFormView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineShipInfoListView), typeof(ReturnByPurchaseDispatchTransactionLineShipInfoListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineWarehouseListView), typeof(ReturnByPurchaseDispatchTransactionLineWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineLineListView), typeof(ReturnByPurchaseDispatchTransactionLineLineListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineSummaryView), typeof(ReturnByPurchaseDispatchTransactionLineSummaryView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineFormView), typeof(ReturnByPurchaseDispatchTransactionLineFormView));
        Routing.RegisterRoute(nameof(SalesProductByCustomerListView), typeof(SalesProductByCustomerListView));
        Routing.RegisterRoute(nameof(ProcurementOptionView), typeof(ProcurementOptionView));
        Routing.RegisterRoute(nameof(ProcurementByCustomerView), typeof(ProcurementByCustomerView));
        Routing.RegisterRoute(nameof(ProcurementByProductView), typeof(ProcurementByProductView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransctionWarehouseListView), typeof(ReturnBySalesDispatchTransctionWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionFicheListView), typeof(ReturnBySalesDispatchTransactionFicheListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineListView), typeof(ReturnBySalesDispatchTransactionLineListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionSelectedLineListView), typeof(ReturnBySalesDispatchTransactionSelectedLineListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionSummaryView), typeof(ReturnBySalesDispatchTransactionSummaryView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionFormView), typeof(ReturnBySalesDispatchTransactionFormView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineWarehouseListView), typeof(ReturnBySalesDispatchTransactionLineWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineLineListView), typeof(ReturnBySalesDispatchTransactionLineLineListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineSelectedLineListView), typeof(ReturnBySalesDispatchTransactionLineSelectedLineListView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineSummaryView), typeof(ReturnBySalesDispatchTransactionLineSummaryView));
        Routing.RegisterRoute(nameof(ReturnBySalesDispatchTransactionLineFormView), typeof(ReturnBySalesDispatchTransactionLineFormView));
        Routing.RegisterRoute(nameof(FastProductionAllProductsListView), typeof(FastProductionAllProductsListView));
        Routing.RegisterRoute(nameof(FastProductionView), typeof(FastProductionView));
        Routing.RegisterRoute(nameof(FastProductionSelectWarehouseListView), typeof(FastProductionSelectWarehouseListView));
        Routing.RegisterRoute(nameof(FastProductionSelectProductListView), typeof(FastProductionSelectProductListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineSupplierView), typeof(ReturnByPurchaseDispatchTransactionLineSupplierView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineShipInfoListView), typeof(ReturnByPurchaseDispatchTransactionLineShipInfoListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineWarehouseListView), typeof(ReturnByPurchaseDispatchTransactionLineWarehouseListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineLineListView), typeof(ReturnByPurchaseDispatchTransactionLineLineListView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineLineChangeBottomSheetView), typeof(ReturnByPurchaseDispatchTransactionLineLineChangeBottomSheetView));
        Routing.RegisterRoute(nameof(ReturnByPurchaseDispatchTransactionLineChangeBottomSheetView), typeof(ReturnByPurchaseDispatchTransactionLineChangeBottomSheetView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderLineChangeBottomSheetView), typeof(DispatchByPurchaseOrderLineChangeBottomSheetView));
        Routing.RegisterRoute(nameof(ProcurementSelectBottomSheetView), typeof(ProcurementSelectBottomSheetView));
        Routing.RegisterRoute(nameof(DispatchByPurchaseOrderChangeBottomSheetView), typeof(DispatchByPurchaseOrderChangeBottomSheetView));
        Routing.RegisterRoute(nameof(TransferTransactionOperationFormView), typeof(TransferTransactionOperationFormView));
        Routing.RegisterRoute(nameof(BarcodePageView), typeof(BarcodePageView));
        Routing.RegisterRoute(nameof(ConfigBottomSheetView), typeof(ConfigBottomSheetView));
        Routing.RegisterRoute(nameof(ProfilePageView), typeof(ProfilePageView));
        Routing.RegisterRoute(nameof(WarehouseCountingFormView), typeof(WarehouseCountingFormView));

    }
    private void StartTimer()
    {
        timer = new System.Threading.Timer(async (_) =>
        {
            await Task.WhenAll(PushSuccessNotification(), PushErrorNotification());
        }, null, TimeSpan.Zero, interval);
    }

    private async Task PushSuccessNotification()
    {

        var serviceProvider = IPlatformApplication.Current.Services;
        using (var scope = serviceProvider.CreateScope())
        {
            var serviceProviderScoped = scope.ServiceProvider;
            var transactionOwnerService = serviceProviderScoped.GetRequiredService<ITransactionOwnerService>();
            var httpService = serviceProviderScoped.GetRequiredService<IHttpClientService>();
            var customQueryService = serviceProvider.GetRequiredService<ICustomQueryService>();

            var httpClient = httpService.GetOrCreateHttpClient();
            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");
            var transactionOwner = await transactionOwnerService.GetObjects(httpClient, $"?$expand=Employee&$filter=IsRead eq false and Employee/Oid eq {employeeOid}");
            if (transactionOwner.IsSuccess)
            {
                foreach (var item in transactionOwner.Data)
                {
                    var result = await customQueryService.GetObjectAsync(httpClient, new NotificationQuery().GetNotificationDetails(item.FicheReferenceId));
                    var obj = Mapping.Mapper.Map<NotificationFiche>(result.Data);

                    var request = new NotificationRequest
                    {
                        Title = obj.TransactionTypeName,
                        NotificationId = item.FicheReferenceId,
                        Subtitle = "Ba�ar�l�",
                        Description = $"{obj.FicheNumber} numaral� fi� ba�ar�yla aktar�lm��t�r.",
                        BadgeNumber = 42,

                    };

                    await LocalNotificationCenter.Current.Show(request);
                    await transactionOwnerService.PatchObject(httpClient, new { IsRead = true }, item.Oid);

                }
            }
            

        }

    }

    private async Task PushErrorNotification()
    {

        var serviceProvider = IPlatformApplication.Current.Services;
        using (var scope = serviceProvider.CreateScope())
        {
            var serviceProviderScoped = scope.ServiceProvider;
            var failureTransactionOwnerService = serviceProviderScoped.GetRequiredService<IFailureTransactionService>();
            var httpService = serviceProviderScoped.GetRequiredService<IHttpClientService>();

            var httpClient = httpService.GetOrCreateHttpClient();
            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");
            var failureTransactionOwner = await failureTransactionOwnerService.GetObjects(httpClient, $"?$expand=Employee&$filter=IsRead eq false and Employee/Oid eq {employeeOid}");

            if (failureTransactionOwner.IsSuccess)
            {
                int index = 0;
                foreach (var item in failureTransactionOwner.Data)
                {

                    var request = new NotificationRequest
                    {
                        Title = "Ba�ar�s�z ��lem",
                        NotificationId = index,
                        Subtitle = "Ba�ar�s�z.",
                        Description = $"{item.Message}",
                        BadgeNumber = 42,

                    };

                    await LocalNotificationCenter.Current.Show(request);
                    index++;

                    await failureTransactionOwnerService.PatchObject(httpClient, new { IsRead = true }, item.Oid);
                }
            }
          

        }

    }


}

