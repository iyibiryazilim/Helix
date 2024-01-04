using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderSummaryView : ContentPage
{
	DispatchByPurchaseOrderSummaryViewModel _viewModel;
	public DispatchByPurchaseOrderSummaryView(DispatchByPurchaseOrderSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}