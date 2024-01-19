using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransctionWarehouseListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineWarehouseListViewModel _viewModel;
	public ReturnBySalesDispatchTransctionWarehouseListView(ReturnBySalesDispatchTransactionLineWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}