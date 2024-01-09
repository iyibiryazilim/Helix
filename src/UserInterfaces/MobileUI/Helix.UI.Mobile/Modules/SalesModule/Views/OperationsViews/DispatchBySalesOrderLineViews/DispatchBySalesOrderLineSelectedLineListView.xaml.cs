using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineSelectedLineListView : ContentPage
{
	private readonly DispatchBySalesOrderLineSelectedLineListViewModel _viewModel;
	public DispatchBySalesOrderLineSelectedLineListView(DispatchBySalesOrderLineSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}