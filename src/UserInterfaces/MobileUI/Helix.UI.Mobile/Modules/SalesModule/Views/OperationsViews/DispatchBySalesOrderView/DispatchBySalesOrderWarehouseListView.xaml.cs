using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderWarehouseListView : ContentPage
{
	private readonly DispatchBySalesOrderWarehouseListViewModel _viewModel;
	public DispatchBySalesOrderWarehouseListView(DispatchBySalesOrderWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
}