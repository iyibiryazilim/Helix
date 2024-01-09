using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderSelectedLineListView : ContentPage
{
	DispatchByPurchaseOrderSelectedLineListViewModel _viewModel;
	public DispatchByPurchaseOrderSelectedLineListView(DispatchByPurchaseOrderSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}