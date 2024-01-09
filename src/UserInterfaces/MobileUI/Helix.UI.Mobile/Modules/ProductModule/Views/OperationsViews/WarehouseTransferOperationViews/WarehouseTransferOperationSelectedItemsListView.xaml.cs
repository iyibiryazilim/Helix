using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;

public partial class WarehouseTransferOperationSelectedItemsListView : ContentPage
{
	WarehouseTransferOperationSelectedItemsListViewModel _viewModel;
	public WarehouseTransferOperationSelectedItemsListView(WarehouseTransferOperationSelectedItemsListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}