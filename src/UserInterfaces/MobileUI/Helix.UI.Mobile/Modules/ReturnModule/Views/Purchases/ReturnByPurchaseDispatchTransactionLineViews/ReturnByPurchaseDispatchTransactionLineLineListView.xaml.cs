using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineLineListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineLineListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineLineListView(ReturnByPurchaseDispatchTransactionLineLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}