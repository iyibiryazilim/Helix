using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;

public partial class OutCountingTransactionOperationView : ContentPage
{
	OutCountingTransactionOperationViewModel _viewModel;

    public OutCountingTransactionOperationView(OutCountingTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}