using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderSupplierView : ContentPage
{
	DispatchByPurchaseOrderSupplierViewModel _viewModel;
	public DispatchByPurchaseOrderSupplierView(DispatchByPurchaseOrderSupplierViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}