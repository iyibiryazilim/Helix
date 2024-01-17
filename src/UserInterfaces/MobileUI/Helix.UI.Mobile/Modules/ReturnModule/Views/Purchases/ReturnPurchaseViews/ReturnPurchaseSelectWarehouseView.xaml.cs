using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;

public partial class ReturnPurchaseSelectWarehouseView : ContentPage
{
	ReturnPurchaseSelectWarehouseViewModel _viewModel;
    public ReturnPurchaseSelectWarehouseView(ReturnPurchaseSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}