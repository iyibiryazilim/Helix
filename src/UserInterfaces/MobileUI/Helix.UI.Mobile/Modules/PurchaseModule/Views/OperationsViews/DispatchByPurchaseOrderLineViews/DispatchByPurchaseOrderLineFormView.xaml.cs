using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineFormView : ContentPage
{
	DispatchByPurchaseOrderLineFormViewModel _viewModel;
	public DispatchByPurchaseOrderLineFormView(DispatchByPurchaseOrderLineFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}