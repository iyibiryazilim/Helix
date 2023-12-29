using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;

public partial class ConsumableTransactionOperationFormView : ContentPage
{
    ConsumableTransactionOperationFormViewModel _viewModel;

    public ConsumableTransactionOperationFormView(ConsumableTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}