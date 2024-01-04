using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderLineListView : ContentPage
{
	DispatchByPurchaseOrderLineListViewModel _viewModel;
	public DispatchByPurchaseOrderLineListView(DispatchByPurchaseOrderLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}