using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineShipInfoListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineShipInfoListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineShipInfoListView(ReturnByPurchaseDispatchTransactionLineShipInfoListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}