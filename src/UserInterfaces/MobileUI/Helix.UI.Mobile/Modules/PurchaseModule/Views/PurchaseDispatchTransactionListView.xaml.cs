using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views;

public partial class PurchaseDispatchTransactionListView : ContentPage
{
	PurchaseDispatchTransactionListViewModel _viewModel;
	public PurchaseDispatchTransactionListView(PurchaseDispatchTransactionListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}