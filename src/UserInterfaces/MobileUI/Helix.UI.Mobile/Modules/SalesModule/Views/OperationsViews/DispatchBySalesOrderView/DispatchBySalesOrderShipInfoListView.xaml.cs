using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderShipInfoListView : ContentPage
{
	private readonly DispatchBySalesOrderShipInfoListViewModel _viewModel;
	public DispatchBySalesOrderShipInfoListView(DispatchBySalesOrderShipInfoListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}