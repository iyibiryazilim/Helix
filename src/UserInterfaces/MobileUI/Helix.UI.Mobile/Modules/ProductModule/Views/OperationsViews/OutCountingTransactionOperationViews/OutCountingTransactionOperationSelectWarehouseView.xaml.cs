using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;

public partial class OutCountingTransactionOperationSelectWarehouseView : ContentPage
{
	private readonly OutCountingTransactionOperationSelectWarehouseViewModel _viewModel;
	public OutCountingTransactionOperationSelectWarehouseView(OutCountingTransactionOperationSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}