using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineSummaryView : ContentPage
{
	readonly DispatchBySalesOrderLineSummaryViewModel _viewModel;
	public DispatchBySalesOrderLineSummaryView(DispatchBySalesOrderLineSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}