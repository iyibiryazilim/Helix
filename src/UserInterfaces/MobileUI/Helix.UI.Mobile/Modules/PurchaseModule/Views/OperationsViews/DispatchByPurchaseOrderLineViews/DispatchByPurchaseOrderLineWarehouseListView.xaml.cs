using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineWarehouseListView : ContentPage
{
	private readonly DispatchByPurchaseOrderLineWarehouseListViewModel _viewModel;
	public DispatchByPurchaseOrderLineWarehouseListView(DispatchByPurchaseOrderLineWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}