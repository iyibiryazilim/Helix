using Android.Content.Res;
using CommunityToolkit.Maui;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.LoginModule.ViewModels;
using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.PanelModule.ViewModels;
using Helix.UI.Mobile.Modules.PanelModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.PurchaseOrderViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.BasketViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.SalesOrderViewModels;
using Helix.UI.Mobile.Modules.SalesModule.Views.BasketViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.PanelViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.SalesOrderViews;
using Microsoft.Extensions.Logging;


namespace Helix.UI.Mobile
{
	public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
				.RegisterHttpClientServices()
				.LoginViews()
				.LoginViewModels()
				.ReturnRegisterServices()
				.ReturnRegisterViewModels()
				.ReturnRegisterViews()
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

#if DEBUG
			builder.Logging.AddDebug();
#endif

            return builder.Build();
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



			return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ICustomerService, CustomerDataStore>();
			mauiAppBuilder.Services.AddTransient<ISalesOrderLineService, SalesOrderLineLineDataStore>();

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



			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<SupplierListViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchaseOrderLineLineListViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchasePanelViewModel>();
			mauiAppBuilder.Services.AddTransient<PurchaseOperationViewModel>();



			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ISupplierService, SupplierDataStore>();
			mauiAppBuilder.Services.AddTransient<IPurchaseOrderLineService, PurchaseOrderLineDataStore>();


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
			mauiAppBuilder.Services.AddTransient<WarehouseDetailView>();

			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
            mauiAppBuilder.Services.AddTransient<WarehouseListViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductListViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductPanelViewModel>();
			mauiAppBuilder.Services.AddTransient<ProductOperationViewModel>();
			mauiAppBuilder.Services.AddTransient<WarehouseDetailViewModel>();

			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
            mauiAppBuilder.Services.AddTransient<IWarehouseService, WarehouseDataStore>();
            mauiAppBuilder.Services.AddTransient<IProductService, ProductDataStore>();
            mauiAppBuilder.Services.AddTransient<IEndProductService, EndProductDataStore>();

            return mauiAppBuilder;
		}
		#endregion

		#region ReturnModule
		public static MauiAppBuilder ReturnRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		public static MauiAppBuilder ReturnRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
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
