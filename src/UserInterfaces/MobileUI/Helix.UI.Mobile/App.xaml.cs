using Helix.UI.Mobile.Modules.LoginModule.ViewModels;
using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews;

namespace Helix.UI.Mobile
{
    public partial class App : Application
    {
		IServiceProvider _serviceProvider;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
			//var service =  Application.Current.Handler.MauiContext.Services.GetService<LoginViewModel>();
			_serviceProvider = serviceProvider;
			var service = _serviceProvider.GetService<LoginViewModel>();
			MainPage = new LoginView(service);



		}
		protected override Window CreateWindow(IActivationState activationState)
		{
			//MainThread.InvokeOnMainThreadAsync(IsLogin);

			return base.CreateWindow(activationState);
		}
		async Task IsLogin()
		{
			
			var result = await SecureStorage.Default.GetAsync("isLogin");
			await Task.Delay(1000);
			bool loginStatus = false;
			if (bool.TryParse(result,out loginStatus))
			{
				if (loginStatus)
				{
					MainPage = new AppShell();

				}
				
			}
			else
			{
			
					//MainPage = new LoginView();

				
			}
			
		}
    }
}
