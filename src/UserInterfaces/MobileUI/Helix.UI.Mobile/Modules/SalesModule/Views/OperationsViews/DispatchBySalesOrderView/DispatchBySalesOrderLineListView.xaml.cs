using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderLineListView : ContentPage
{
	DispatchBySalesOrderLineListViewModel _viewModel;
    public DispatchBySalesOrderLineListView(DispatchBySalesOrderLineListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}