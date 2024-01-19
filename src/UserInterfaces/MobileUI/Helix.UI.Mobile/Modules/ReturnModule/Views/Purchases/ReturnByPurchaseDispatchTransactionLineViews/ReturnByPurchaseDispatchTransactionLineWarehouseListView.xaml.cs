using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineWarehouseListView : ContentPage
{
	ReturnByPurchaseDispatchTransactionLineWarehouseListViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineWarehouseListView(ReturnByPurchaseDispatchTransactionLineWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}