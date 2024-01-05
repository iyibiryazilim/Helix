using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineLineListView : ContentPage
{
	readonly DispatchBySalesOrderLineLineListViewModel _viewModel;
	public DispatchBySalesOrderLineLineListView(DispatchBySalesOrderLineLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}