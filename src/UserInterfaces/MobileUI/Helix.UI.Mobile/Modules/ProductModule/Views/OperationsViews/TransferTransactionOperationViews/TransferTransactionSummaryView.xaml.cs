using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class TransferTransactionSummaryView : ContentPage
{
	TransferTransactionSummaryViewModel _viewModel;
	public TransferTransactionSummaryView(TransferTransactionSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}