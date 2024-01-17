using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineWarehouseListView : ContentPage
{
	private readonly DispatchBySalesOrderLineWarehouseListViewModel _viewModel;
	public DispatchBySalesOrderLineWarehouseListView(DispatchBySalesOrderLineWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
}