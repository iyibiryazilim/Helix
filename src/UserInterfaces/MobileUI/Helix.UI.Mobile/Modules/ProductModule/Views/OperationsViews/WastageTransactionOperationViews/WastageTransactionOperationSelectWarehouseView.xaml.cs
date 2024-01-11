using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;

public partial class WastageTransactionOperationSelectWarehouseView : ContentPage
{
	private readonly WastageTransactionOperationSelectWarehouseViewModel _viewModel;
	public WastageTransactionOperationSelectWarehouseView(WastageTransactionOperationSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}