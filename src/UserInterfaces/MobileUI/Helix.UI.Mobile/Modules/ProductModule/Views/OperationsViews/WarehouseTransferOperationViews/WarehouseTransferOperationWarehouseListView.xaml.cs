using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;

public partial class WarehouseTransferOperationWarehouseListView : ContentPage
{
	WarehouseTransferOperationWarehouseListViewModel _viewModel;
	public WarehouseTransferOperationWarehouseListView(WarehouseTransferOperationWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}