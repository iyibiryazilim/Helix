using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;

public partial class InCountingTransactionOperationView : ContentPage
{
	InCountingTransactionOperationViewModel _viewModel;

    public InCountingTransactionOperationView(InCountingTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}