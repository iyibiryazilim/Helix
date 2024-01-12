using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class ExitWarehouseSelectView : ContentPage
{
	ExitWarehouseSelectViewModel _viewModel;
	public ExitWarehouseSelectView(ExitWarehouseSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}