using Helix.UI.Mobile.Modules.LoginModule.Views;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews;

namespace Helix.UI.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			if (SecureStorage.Default.GetAsync("isLogin")!=null)
			{
				MainPage = new AppShell();

			}
			else
			{
				MainPage = new LoginView();

			}



		}
    }
}
