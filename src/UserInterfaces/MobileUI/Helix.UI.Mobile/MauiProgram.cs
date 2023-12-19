using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.SalesOrderViews;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.SalesOrderViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Services;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
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
			mauiAppBuilder.Services.AddTransient<WaitingSalesOrderLineListView>();


			return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<CustomerListViewModel>();
			mauiAppBuilder.Services.AddTransient<WaitingSalesOrderLineListViewModel>();

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
			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		public static MauiAppBuilder PurchaseRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		#endregion

		#region ProductModule
		public static MauiAppBuilder ProductRegisterViews(this MauiAppBuilder mauiAppBuilder)
		{
            mauiAppBuilder.Services.AddTransient<WarehouseListView>();
            return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
            mauiAppBuilder.Services.AddTransient<WarehouseListViewModel>();
            return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
            mauiAppBuilder.Services.AddTransient<IWarehouseService, WarehouseDataStore>();
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

	}
}
