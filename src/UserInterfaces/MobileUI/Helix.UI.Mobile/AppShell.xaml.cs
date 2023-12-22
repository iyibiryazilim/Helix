﻿using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;

namespace Helix.UI.Mobile
{
	public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
			Routing.RegisterRoute(nameof(ProductListView), typeof(ProductListView));
			Routing.RegisterRoute(nameof(ProductDetailView), typeof(ProductDetailView));
			Routing.RegisterRoute(nameof(WarehouseDetailView), typeof(WarehouseDetailView));
			Routing.RegisterRoute(nameof(CustomerDetailView), typeof(CustomerDetailView));
			Routing.RegisterRoute(nameof(WarehouseDetailInputTransactionView), typeof(WarehouseDetailInputTransactionView));
			Routing.RegisterRoute(nameof(WarehouseDetailOutputTransactionView), typeof(WarehouseDetailOutputTransactionView));
			Routing.RegisterRoute(nameof(WarehouseDetailProductListView), typeof(WarehouseDetailProductListView));

		}
	}
}
