using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionSummaryView : ContentPage
{
	ReturnByPurchaseDispatchTransactionSummaryViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionSummaryView(ReturnByPurchaseDispatchTransactionSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}