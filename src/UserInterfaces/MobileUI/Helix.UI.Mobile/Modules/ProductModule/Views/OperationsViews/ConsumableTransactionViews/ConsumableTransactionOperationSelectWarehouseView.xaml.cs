using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;

public partial class ConsumableTransactionOperationSelectWarehouseView : ContentPage
{
	private readonly ConsumableTransactionOperationSelectWarehouseViewModel _viewModel;
	public ConsumableTransactionOperationSelectWarehouseView(ConsumableTransactionOperationSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}