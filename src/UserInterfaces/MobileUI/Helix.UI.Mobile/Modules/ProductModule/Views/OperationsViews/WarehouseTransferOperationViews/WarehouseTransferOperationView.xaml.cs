using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;

public partial class WarehouseTransferOperationView : ContentPage
{
	WarehouseTransferOperationViewModel _viewModel;
	public WarehouseTransferOperationView(WarehouseTransferOperationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}