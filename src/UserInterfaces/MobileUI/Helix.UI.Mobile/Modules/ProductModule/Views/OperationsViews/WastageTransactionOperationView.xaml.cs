using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class WastageTransactionOperationView : ContentPage
{
	WastageTransactionOperationViewModel _viewModel;
    public WastageTransactionOperationView(WastageTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}