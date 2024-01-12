using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class EntryWarehouseSelectView : ContentPage
{
	EntryWarehouseSelectViewModel _viewModel;
	public EntryWarehouseSelectView(EntryWarehouseSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}