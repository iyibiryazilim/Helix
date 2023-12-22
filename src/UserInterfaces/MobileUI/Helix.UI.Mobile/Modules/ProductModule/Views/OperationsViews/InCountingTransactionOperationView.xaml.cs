using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class InCountingTransactionOperationView : ContentPage
{
	InCountingTransactionOperationViewModel _viewModel;
    public InCountingTransactionOperationView(InCountingTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}