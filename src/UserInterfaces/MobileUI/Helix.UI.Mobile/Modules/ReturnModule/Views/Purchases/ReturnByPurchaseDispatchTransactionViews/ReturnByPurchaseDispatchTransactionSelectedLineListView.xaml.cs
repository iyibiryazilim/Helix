using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionSelectedLineListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionSelectedLineListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionSelectedLineListView(ReturnByPurchaseDispatchTransactionSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}