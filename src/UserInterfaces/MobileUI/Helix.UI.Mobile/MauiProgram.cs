using Android.Content.Res;
using CommunityToolkit.Maui;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.DataStores;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.BaseModule.ViewModels;
using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;
using Helix.UI.Mobile.Modules.BaseModule.Views;
using Helix.UI.Mobile.Modules.BaseModule.Views.Current;
using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.ViewModels;
using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.PanelModule.ViewModels;
using Helix.UI.Mobile.Modules.PanelModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionFormViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationFormViewModel;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.PurchaseOrderViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Panel;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Panel;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.BasketViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.SalesOrderViewModels;
using Helix.UI.Mobile.Modules.SalesModule.Views.BasketViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.SalesOrderViews;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;


namespace Helix.UI.Mobile
{
    public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseBottomSheet()
				 .UseMauiCommunityToolkit()
				.RegisterHttpClientServices()
				.LoginViews()
				.LoginViewModels()
				.ReturnRegisterServices()
				.ReturnRegisterViewModels()
				.ReturnRegisterViews()
				.BaseRegisterServices()
				.SalesRegisterServices()
				.SalesRegisterViewModels()
				.SalesRegisterViews()
				.PurchaseRegisterViews()
				.PurchaseRegisterViewModels()
				.PurchaseRegisterServices()
				.ProductRegisterServices()
				.ProductRegisterViewModels()
				.ProductRegisterViews()
				.PanelViewModels()
				.PanelViews()
				.FastProductionViewModels()
				.FastProductionViews()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

					fonts.AddFont("RobotoSlab-Black.ttf", "RobotoSlabBlack");
					fonts.AddFont("RobotoSlab-Bold.ttf", "RobotoSlabBold");
					fonts.AddFont("RobotoSlab-ExtraBold.ttf", "RobotoSlabExtraBold");
					fonts.AddFont("RobotoSlab-ExtraLight.ttf", "RobotoSlabExtraLight");
					fonts.AddFont("RobotoSlab-Light.ttf", "RobotoSlabLight");
					fonts.AddFont("RobotoSlab-Medium.ttf", "RobotoSlabMedium");
					fonts.AddFont("RobotoSlab-Regular.ttf", "RobotoSlabRegular");
					fonts.AddFont("RobotoSlab-SemiBold.ttf", "RobotoSlabSemiBold");
					fonts.AddFont("RobotoSlab-Thin.ttf", "RobotoSlabThin");

					fonts.AddFont("Roboto-Black.ttf", "RobotoBlack");
					fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
					fonts.AddFont("Roboto-ExtraBold.ttf", "RobotoExtraBold");
					fonts.AddFont("Roboto-ExtraLight.ttf", "RobotoExtraLight");
					fonts.AddFont("Roboto-Light.ttf", "RobotoLight");
					fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
					fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
					fonts.AddFont("Roboto-SemiBold.ttf", "RobotoSemiBold");
					fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");

					fonts.AddFont("fa-solid.otf", "FAS");
					fonts.AddFont("fa-regular.otf", "FAR");
					fonts.AddFont("fa-brands.otf", "FAB");
				});
			Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
			{
#if ANDROID
				handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
			});

            Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping(nameof(TimePicker), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping(nameof(DatePicker), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });







#if DEBUG
            builder.Logging.AddDebug();
#endif

			return builder.Build();
		}


		public static MauiAppBuilder BaseRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{

			mauiAppBuilder.Services.AddTransient<ICustomQueryService, CustomQueryDataStore>();
			mauiAppBuilder.Services.AddTransient<CurrentShowMoreBottomSheetView>();
			mauiAppBuilder.Services.AddTransient<CurrentShowMoreBottomSheetViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentInputListView>();
			mauiAppBuilder.Services.AddTransient<CurrentInputListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentOutputListView>();
			mauiAppBuilder.Services.AddTransient<CurrentOutputListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseOrderListView>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseOrderListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesOrderListView>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesOrderListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesReturnListView>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesReturnListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseReturnListView>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseReturnListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseDispatchListView>();
			mauiAppBuilder.Services.AddTransient<CurrentPurchaseDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesDispatchListView>();
			mauiAppBuilder.Services.AddTransient<CurrentSalesDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<SuccessPageView>();
			mauiAppBuilder.Services.AddTransient<SuccessPageViewModel>();
			mauiAppBuilder.Services.AddTransient<FailedPageView>();
			mauiAppBuilder.Services.AddTransient<FailedPageViewModel>();
		



			return mauiAppBuilder;
		}
		public static MauiAppBuilder RegisterHttpClientServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<IHttpClientService, HttpClientService>();
			return mauiAppBuilder;

		}

		#region SalesModule
		public static MauiAppBuilder SalesRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<CustomerListView>();
			mauiAppBuilder.Services.AddTransient<CustomerDetailView>();
			mauiAppBuilder.Services.AddTransient<WaitingSalesOrderLineListView>();
			mauiAppBuilder.Services.AddTransient<SalesPanelView>();
			mauiAppBuilder.Services.AddTransient<SalesOperationView>();
			mauiAppBuilder.Services.AddTransient<BasketView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderCustomerView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderFicheView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderFormView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineListView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderSummaryView>();
			mauiAppBuilder.Services.AddTransient<CustomerFastOperationBottomSheetView>();
			mauiAppBuilder.Services.AddTransient<SalesDispatchListView>();
			mauiAppBuilder.Services.AddTransient<SalesDispatchFormView>();
			mauiAppBuilder.Services.AddTransient<SalesDispatchFormContentView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineFormViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineCustomerView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineFormView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineLineListView>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineSummaryView>();
            mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderSelectedLineListView>();
            mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineSelectedLineListView>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationSelectWarehouseView>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionCustomerView>();






            return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<CustomerListViewModel>();
			mauiAppBuilder.Services.AddTransient<CustomerDetailViewModel>();
			mauiAppBuilder.Services.AddTransient<WaitingSalesOrderLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<SalesPanelViewModel>();
			mauiAppBuilder.Services.AddTransient<SalesOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<BasketViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderCustomerViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderFicheViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderFormViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderSummaryViewModel>();
			mauiAppBuilder.Services.AddTransient<CustomerFastOperationBottomSheetViewModel>();
			mauiAppBuilder.Services.AddScoped<SalesDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<SalesDispatchFormViewModel>();
			mauiAppBuilder.Services.AddTransient<SalesDispatchFormContentViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineCustomerViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineFormViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineSummaryViewModel>();
            mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderSelectedLineListViewModel>();
            mauiAppBuilder.Services.AddTransient<DispatchBySalesOrderLineSelectedLineListViewModel>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationSelectWarehouseViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionCustomerViewModel>();








            return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ICustomerService, CustomerDataStore>();
			mauiAppBuilder.Services.AddTransient<ICustomerTransactionLineService, CustomerTransactionLineDataStore>();
			mauiAppBuilder.Services.AddTransient<ICustomerTransactionService, CustomerTransactionDataStore>();
			mauiAppBuilder.Services.AddTransient<ISalesOrderLineService, SalesOrderLineLineDataStore>();
			mauiAppBuilder.Services.AddTransient<ISalesOrderService, SalesOrderDataStore>();
			mauiAppBuilder.Services.AddTransient<IDriverService,DriverDataStore>();
			mauiAppBuilder.Services.AddTransient<ICarrierService,CarrierDataStore>();
			mauiAppBuilder.Services.AddTransient<ISpeCodeService,SpeCodeDataStore>();
			mauiAppBuilder.Services.AddTransient<IShipInfoService, ShipInfoDataStore>();	


			return mauiAppBuilder;
		}
		#endregion

		#region PurchaseModule
		public static MauiAppBuilder PurchaseRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<SupplierListView>();
			mauiAppBuilder.Services.AddTransient<PurchaseOrderLineListView>();
			mauiAppBuilder.Services.AddTransient<PurchasePanelViews>();
			mauiAppBuilder.Services.AddTransient<PurchaseOperationView>();
			mauiAppBuilder.Services.AddTransient<SupplierDetailView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSupplierView>();
			mauiAppBuilder.Services.AddTransient<PurchaseDispatchListView>();
			mauiAppBuilder.Services.AddTransient<PurchaseDispatchFormView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderFicheView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderFormView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineListView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSummaryView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSummaryView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineLineListView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSupplierView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSelectedLineListView>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSelectedLineListView>();
			mauiAppBuilder.Services.AddTransient<SupplierFastOperationBottomSheetView>();
			


			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<SupplierListViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchaseOrderLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchasePanelViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchaseOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<SupplierDetailViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSupplierViewModel>();
			mauiAppBuilder.Services.AddScoped<PurchaseDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchaseDispatchFormViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderFicheViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderFormViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSummaryViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSupplierViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSummaryViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderSelectedLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<DispatchByPurchaseOrderLineSelectedLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<SupplierFastOperationBottomSheetViewModel>();





			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ISupplierService, SupplierDataStore>();
			mauiAppBuilder.Services.AddTransient<IPurchaseOrderLineService, PurchaseOrderLineDataStore>();
			mauiAppBuilder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderDataStore>();
			mauiAppBuilder.Services.AddTransient<ISupplierTransactionLineService, SupplierTransactionLineDataStore>();
			mauiAppBuilder.Services.AddTransient<ISupplierTransactionService, SupplierTransactionDataStore>();




			return mauiAppBuilder;
		}
		#endregion

		#region ProductModule
		public static MauiAppBuilder ProductRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<WarehouseListView>();
			mauiAppBuilder.Services.AddTransient<ProductListView>();
			mauiAppBuilder.Services.AddTransient<ProductPanelView>();
			mauiAppBuilder.Services.AddTransient<ProductOperationView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailView>();
			mauiAppBuilder.Services.AddTransient<ProductFastOperationBottomSheetView>();
			mauiAppBuilder.Services.AddTransient<ProductTransactionBottomSheetView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailInputReturnListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailInputTransactionListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailOutputReturnListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailOutputTransactionListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailPurchaseDispatchListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailPurchaseOrderListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailSalesDispatchListView>();
			mauiAppBuilder.Services.AddTransient<ProductDetailSalesOrderListView>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailView>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailBottomSheetView>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailProductListView>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailOutputTransactionView>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailInputTransactionView>();
			mauiAppBuilder.Services.AddTransient<ProductionTransactionOperationView>();
			mauiAppBuilder.Services.AddTransient<OutCountingTransactionOperationView>();
			mauiAppBuilder.Services.AddTransient<InCountingTransactionOperationView>();
			mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationView>();
			mauiAppBuilder.Services.AddTransient<WastageTransactionOperationView>();
			mauiAppBuilder.Services.AddTransient<SharedProductListView>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationFormView>();
			mauiAppBuilder.Services.AddTransient<OutCountingTransactionOperationFormView>();
			mauiAppBuilder.Services.AddTransient<ProductionTransactionOperationFormView>();
			mauiAppBuilder.Services.AddTransient<WastageTransactionOperationFormView>();
			mauiAppBuilder.Services.AddTransient<ProductTransactionOperationFormContentView>();
			mauiAppBuilder.Services.AddTransient<InCountingTransactionOperationFormView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationSelectedItemsListView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationFormView>();
            mauiAppBuilder.Services.AddTransient<WastageTransactionOperationSelectWarehouseView>();
            mauiAppBuilder.Services.AddTransient<ProductionTransactionOperationSelectWarehouseView>();
            mauiAppBuilder.Services.AddTransient<OutCountingTransactionOperationSelectWarehouseView>();
            mauiAppBuilder.Services.AddTransient<InCountingTransactionOperationSelectWarehouseView>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationSelectWarehouseView>();
            mauiAppBuilder.Services.AddTransient<ProductDetailWarehouseTotalView>();
            mauiAppBuilder.Services.AddTransient<ProductDetailWarehouseParametersView>();
            mauiAppBuilder.Services.AddTransient<ProductDetailSubUnitsetsAndBarcodeView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationWarehouseListView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationTransferredWarehouseListView>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationSummaryView>();
 			mauiAppBuilder.Services.AddTransient<ExitProductSelectView>();
 			mauiAppBuilder.Services.AddTransient<ExitWarehouseSelectView>();
			mauiAppBuilder.Services.AddTransient<TransferTransactionSummaryView>();
			mauiAppBuilder.Services.AddTransient<ChangeProductView>();

			mauiAppBuilder.Services.AddTransient<EntryWarehouseSelectView>();
			 


			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<WarehouseListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductPanelViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductFastOperationBottomSheetViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductTransactionBottomSheetViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailBottomSheetViewModel>();
			mauiAppBuilder.Services.AddScoped<ProductionTransactionOperationViewModel>();
			mauiAppBuilder.Services.AddScoped<OutCountingTransactionOperationViewModel>();
			mauiAppBuilder.Services.AddScoped<InCountingTransactionOperationViewModel>();
			mauiAppBuilder.Services.AddScoped<ConsumableTransactionOperationViewModel>();
			mauiAppBuilder.Services.AddScoped<WastageTransactionOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailInputTransactionViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailOutputTransactionViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailProductListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailInputReturnListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailInputTransactionListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailOutputReturnListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailOutputTransactionListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailPurchaseDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailPurchaseOrderListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailSalesDispatchListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductDetailSalesOrderListViewModel>();
			mauiAppBuilder.Services.AddTransient<SharedProductListViewModel>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationFormViewModel>();
            mauiAppBuilder.Services.AddTransient<OutCountingTransactionOperationFormViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductionTransactionOperationFormViewModel>();
            mauiAppBuilder.Services.AddTransient<WastageTransactionOperationFormViewModel>();
			mauiAppBuilder.Services.AddTransient<InCountingTransactionOperationFormViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationSelectedItemsListViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationFormViewModel>();
            mauiAppBuilder.Services.AddTransient<WastageTransactionOperationSelectWarehouseViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductionTransactionOperationSelectWarehouseViewModel>();
            mauiAppBuilder.Services.AddTransient<OutCountingTransactionOperationSelectWarehouseViewModel>();
            mauiAppBuilder.Services.AddTransient<InCountingTransactionOperationSelectWarehouseViewModel>();
            mauiAppBuilder.Services.AddTransient<ConsumableTransactionOperationSelectWarehouseViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductDetailWarehouseTotalViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductDetailWarehouseParametersViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductDetailSubUnitsetsAndBarcodeViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationWarehouseListViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationTransferredWarehouseListViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseTransferOperationSummaryViewModel>();
 			mauiAppBuilder.Services.AddTransient<ExitProductSelectViewModel>();
 			mauiAppBuilder.Services.AddTransient<ExitWarehouseSelectViewModel>();
			mauiAppBuilder.Services.AddTransient<TransferTransactionSummaryViewModel>();
			mauiAppBuilder.Services.AddTransient<ChangeProductViewModel>();
			mauiAppBuilder.Services.AddTransient<EntryWarehouseSelectViewModel>();


			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<IWarehouseService, WarehouseDataStore>();
			mauiAppBuilder.Services.AddTransient<IProductService, ProductDataStore>();
			mauiAppBuilder.Services.AddTransient<IEndProductService, EndProductDataStore>();
			mauiAppBuilder.Services.AddTransient<IProductTransactionLineService, ProductTransactionLineDataStore>();
			mauiAppBuilder.Services.AddTransient<IWarehouseTransactionService, WarehouseTransactionDataStore>();
			mauiAppBuilder.Services.AddTransient<IWarehouseTotalService, WarehouseTotalDataStore>();
			mauiAppBuilder.Services.AddTransient<IWarehouseParameterService, WarehouseParameterDataStore>();
 
			

			return mauiAppBuilder;
		}
		#endregion

		#region ReturnModule
		public static MauiAppBuilder ReturnRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ReturnPanelView>();
			mauiAppBuilder.Services.AddTransient<ReturnPurchasesView>();
			mauiAppBuilder.Services.AddTransient<ReturnSalesView>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionCustomerView>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionLineCustomerView>();
			mauiAppBuilder.Services.AddTransient<ReturnByPurchaseDispatchTransactionSupplierView>();

			return mauiAppBuilder;
		}
		public static MauiAppBuilder ReturnRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ReturnPanelViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnPurchasesViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnSalesViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionCustomerViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnBySalesDispatchTransactionLineCustomerViewModel>();
			mauiAppBuilder.Services.AddTransient<ReturnByPurchaseDispatchTransactionSupplierViewModel>();

			return mauiAppBuilder;
		}
		public static MauiAppBuilder ReturnRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		#endregion

		#region LoginModule
		public static MauiAppBuilder LoginViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<LoginView>();
			return mauiAppBuilder;
		}
		public static MauiAppBuilder LoginViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
			return mauiAppBuilder;
		}

		#endregion

		#region PanelModule
		public static MauiAppBuilder PanelViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<PanelView>();
			return mauiAppBuilder;
		}
		public static MauiAppBuilder PanelViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<PanelViewModel>();

			return mauiAppBuilder;
		}

		#endregion

		#region FastProductionModule
		public static MauiAppBuilder FastProductionViews(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<FastProductionView>();
			return mauiAppBuilder;
		}
		public static MauiAppBuilder FastProductionViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<FastProductionViewModel>();

			return mauiAppBuilder;
		}

		#endregion

	}
}
