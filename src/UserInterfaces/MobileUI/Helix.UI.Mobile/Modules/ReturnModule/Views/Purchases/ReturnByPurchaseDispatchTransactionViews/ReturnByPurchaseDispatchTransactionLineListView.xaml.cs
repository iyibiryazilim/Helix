using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionLineListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineListView(ReturnByPurchaseDispatchTransactionLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}