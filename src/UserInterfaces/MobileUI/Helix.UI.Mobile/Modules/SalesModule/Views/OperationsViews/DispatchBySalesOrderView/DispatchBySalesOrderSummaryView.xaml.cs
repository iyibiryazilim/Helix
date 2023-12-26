using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderSummaryView : ContentPage
{
	DispatchBySalesOrderSummaryViewModel _viewModel;
    public DispatchBySalesOrderSummaryView(DispatchBySalesOrderSummaryViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}