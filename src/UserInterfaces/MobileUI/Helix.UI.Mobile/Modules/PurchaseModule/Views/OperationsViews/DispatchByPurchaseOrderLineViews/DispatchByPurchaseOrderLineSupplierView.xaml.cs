using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineSupplierView : ContentPage
{
	DispatchByPurchaseOrderLineSupplierViewModel _viewModel;
	public DispatchByPurchaseOrderLineSupplierView(DispatchByPurchaseOrderLineSupplierViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}