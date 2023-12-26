using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;

public partial class WastageTransactionOperationView : ContentPage
{
	WastageTransactionOperationViewModel _viewModel;
    public WastageTransactionOperationView(WastageTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
	}
}