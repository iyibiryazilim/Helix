using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;

public partial class InCountingTransactionOperationFormView : ContentPage
{
	InCountingTransactionOperationFormViewModel _viewModel;
    public InCountingTransactionOperationFormView(InCountingTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;

    }
}