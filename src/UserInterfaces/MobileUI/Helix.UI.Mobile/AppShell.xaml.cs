using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;

namespace Helix.UI.Mobile
{
	public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
			Routing.RegisterRoute(nameof(ProductListView), typeof(ProductListView));
			Routing.RegisterRoute(nameof(CustomerDetailView), typeof(CustomerDetailView));

		}
	}
}
