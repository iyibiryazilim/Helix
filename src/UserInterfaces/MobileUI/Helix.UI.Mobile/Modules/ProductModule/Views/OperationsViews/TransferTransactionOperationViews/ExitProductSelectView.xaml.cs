using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class ExitProductSelectView : ContentPage
{
	ExitProductSelectViewModel _viewModel;
	public ExitProductSelectView(ExitProductSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}