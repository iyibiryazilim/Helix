using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineLineListView : ContentPage
{
	DispatchByPurchaseOrderLineLineListViewModel _viewModel;
	public DispatchByPurchaseOrderLineLineListView(DispatchByPurchaseOrderLineLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}