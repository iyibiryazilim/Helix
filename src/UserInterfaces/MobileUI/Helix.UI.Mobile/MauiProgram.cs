using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;

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
			return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		public static MauiAppBuilder SalesRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<ICustomerService, CustomerDataStore>();
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
			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			return mauiAppBuilder;
		}
		public static MauiAppBuilder ProductRegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
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
