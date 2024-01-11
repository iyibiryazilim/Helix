using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;

public partial class WarehouseTransferOperationTransferredWarehouseListView : ContentPage
{
	WarehouseTransferOperationTransferredWarehouseListViewModel _viewModel;
	public WarehouseTransferOperationTransferredWarehouseListView(WarehouseTransferOperationTransferredWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}