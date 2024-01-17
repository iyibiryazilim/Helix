using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderWarehouseListView : ContentPage
{
	private readonly DispatchByPurchaseOrderWarehouseListViewModel _viewModel;
	public DispatchByPurchaseOrderWarehouseListView(DispatchByPurchaseOrderWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}