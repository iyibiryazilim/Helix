using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;

public partial class ConsumableTransactionOperationFormView : ContentPage
{
	ConsumableTransactionOperationViewModel _viewModel;

    public ConsumableTransactionOperationFormView(ConsumableTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}