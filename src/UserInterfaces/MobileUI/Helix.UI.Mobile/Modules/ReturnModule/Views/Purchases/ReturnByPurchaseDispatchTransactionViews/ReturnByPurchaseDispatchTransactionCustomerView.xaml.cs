using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionCustomerView : ContentPage
{
	ReturnByPurchaseDispatchTransactionCustomerViewModel _viewModel;
    public ReturnByPurchaseDispatchTransactionCustomerView(ReturnByPurchaseDispatchTransactionCustomerViewModel viewModel )
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}