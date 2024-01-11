using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionSupplierView : ContentPage
{
    ReturnByPurchaseDispatchTransactionSupplierViewModel _viewModel;
    public ReturnByPurchaseDispatchTransactionSupplierView(ReturnByPurchaseDispatchTransactionSupplierViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}