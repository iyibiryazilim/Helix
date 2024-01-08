using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderSelectedLineListView : ContentPage
{
	private readonly DispatchBySalesOrderSelectedLineListViewModel _viewModel;
	public DispatchBySalesOrderSelectedLineListView(DispatchBySalesOrderSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}