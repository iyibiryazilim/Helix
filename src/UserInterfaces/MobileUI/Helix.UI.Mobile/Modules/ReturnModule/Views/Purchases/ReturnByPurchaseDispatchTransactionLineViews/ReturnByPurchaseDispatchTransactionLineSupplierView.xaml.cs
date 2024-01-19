using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineSupplierView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineSupplierViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineSupplierView(ReturnByPurchaseDispatchTransactionLineSupplierViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}