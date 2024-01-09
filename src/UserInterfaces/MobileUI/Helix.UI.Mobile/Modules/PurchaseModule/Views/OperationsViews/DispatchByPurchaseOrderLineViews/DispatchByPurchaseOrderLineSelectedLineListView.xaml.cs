using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineSelectedLineListView : ContentPage
{
	DispatchByPurchaseOrderLineSelectedLineListViewModel _viewModel;
	public DispatchByPurchaseOrderLineSelectedLineListView(DispatchByPurchaseOrderLineSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}