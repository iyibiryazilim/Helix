using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;

public partial class OutCountingTransactionOperationFormView : ContentPage
{
	OutCountingTransactionOperationFormViewModel _viewModel;
    public OutCountingTransactionOperationFormView(OutCountingTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}