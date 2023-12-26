using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Microsoft.Maui.Hosting;

namespace Helix.UI.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {

        InitializeComponent();
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
		Routing.RegisterRoute(nameof(CustomerShowMoreBottomSheetView), typeof(CustomerShowMoreBottomSheetView));
		Routing.RegisterRoute(nameof(CustomerFastOperationBottomSheetView), typeof(CustomerFastOperationBottomSheetView));




	}
}

