namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionFormView : ContentPage
{
	ReturnByPurchaseDispatchTransactionFormView _viewModel;
	public ReturnByPurchaseDispatchTransactionFormView(ReturnByPurchaseDispatchTransactionFormView viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}