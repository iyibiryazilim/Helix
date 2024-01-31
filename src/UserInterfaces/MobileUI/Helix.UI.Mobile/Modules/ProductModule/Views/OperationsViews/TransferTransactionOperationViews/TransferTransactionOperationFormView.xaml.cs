using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class TransferTransactionOperationFormView : ContentPage
{
	private readonly TransferTransactionOperationFormViewModel _viewModel;
	public TransferTransactionOperationFormView(TransferTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}