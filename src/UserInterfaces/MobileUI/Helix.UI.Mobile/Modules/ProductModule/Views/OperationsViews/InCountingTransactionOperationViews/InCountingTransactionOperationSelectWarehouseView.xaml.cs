using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationFormViewModel;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;

public partial class InCountingTransactionOperationSelectWarehouseView : ContentPage
{
	private readonly InCountingTransactionOperationSelectWarehouseViewModel _viewModel;
	public InCountingTransactionOperationSelectWarehouseView(InCountingTransactionOperationSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}