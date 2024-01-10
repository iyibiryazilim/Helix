using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;

public partial class WarehouseTransferOperationFormView : ContentPage
{
	WarehouseTransferOperationFormViewModel _viewModel;
	public WarehouseTransferOperationFormView(WarehouseTransferOperationFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}