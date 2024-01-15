using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;

public partial class EntryProductSelectView : ContentPage
{
	EntryProductSelectViewModel _viewModel;
	public EntryProductSelectView(EntryProductSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}