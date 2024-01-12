using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class ChangeProductView : ContentPage
{
	ChangeProductViewModel _viewModel;
	public ChangeProductView(ChangeProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}