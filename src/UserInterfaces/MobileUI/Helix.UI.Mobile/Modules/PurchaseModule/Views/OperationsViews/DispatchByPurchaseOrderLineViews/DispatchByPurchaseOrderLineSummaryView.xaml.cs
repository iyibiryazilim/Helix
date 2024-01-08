using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineSummaryView : ContentPage
{
	DispatchByPurchaseOrderLineSummaryViewModel _viewModel;
	public DispatchByPurchaseOrderLineSummaryView(DispatchByPurchaseOrderLineSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}