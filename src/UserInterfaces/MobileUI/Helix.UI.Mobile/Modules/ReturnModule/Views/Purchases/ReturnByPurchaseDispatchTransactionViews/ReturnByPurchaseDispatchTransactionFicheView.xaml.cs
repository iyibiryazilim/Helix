using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionFicheView : ContentPage
{
	ReturnByPurchaseDispatchTransactionFicheViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionFicheView(ReturnByPurchaseDispatchTransactionFicheViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}