using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineFormView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineFormViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineFormView(ReturnByPurchaseDispatchTransactionLineFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}