using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineSummaryView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineSummaryViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineSummaryView(ReturnByPurchaseDispatchTransactionLineSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}