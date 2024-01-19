using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineWarehouseListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineWarehouseListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineWarehouseListView(ReturnBySalesDispatchTransactionLineWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}