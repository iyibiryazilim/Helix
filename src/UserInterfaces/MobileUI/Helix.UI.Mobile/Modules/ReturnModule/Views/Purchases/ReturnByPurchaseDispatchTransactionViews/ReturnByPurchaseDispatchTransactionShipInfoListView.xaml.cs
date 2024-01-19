using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionShipInfoListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionShipInfoListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionShipInfoListView(ReturnByPurchaseDispatchTransactionShipInfoListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
}