using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class OutCountingTransactionOperationView : ContentPage
{
	OutCountingTransactionOperationViewModel _viewModel;
    public OutCountingTransactionOperationView(OutCountingTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}