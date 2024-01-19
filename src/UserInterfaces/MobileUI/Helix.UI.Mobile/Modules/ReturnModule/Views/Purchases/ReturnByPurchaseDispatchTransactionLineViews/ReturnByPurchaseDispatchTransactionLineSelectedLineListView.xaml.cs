using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineSelectedLineListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineSelectedLineListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineSelectedLineListView(ReturnByPurchaseDispatchTransactionLineSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}