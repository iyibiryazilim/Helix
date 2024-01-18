using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineShipInfoListView : ContentPage
{
	private readonly DispatchBySalesOrderLineShipInfoListViewModel _viewModel;
	public DispatchBySalesOrderLineShipInfoListView(DispatchBySalesOrderLineShipInfoListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}