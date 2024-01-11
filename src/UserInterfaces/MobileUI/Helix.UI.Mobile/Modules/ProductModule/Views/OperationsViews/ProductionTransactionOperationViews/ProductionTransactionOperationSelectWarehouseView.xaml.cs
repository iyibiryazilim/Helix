using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;

public partial class ProductionTransactionOperationSelectWarehouseView : ContentPage
{
	private readonly ProductionTransactionOperationSelectWarehouseViewModel _viewModel;
	public ProductionTransactionOperationSelectWarehouseView(ProductionTransactionOperationSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}