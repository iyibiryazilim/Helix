using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;

public partial class ConsumableTransactionOperationView : ContentPage
{
	ConsumableTransactionOperationViewModel _viewModel;
    public ConsumableTransactionOperationView(ConsumableTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}