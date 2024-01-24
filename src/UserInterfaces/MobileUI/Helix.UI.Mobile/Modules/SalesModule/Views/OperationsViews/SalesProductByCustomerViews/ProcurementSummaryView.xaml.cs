using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementSummaryView : ContentPage
{
	ProcurementSummaryViewModel _viewModel;
    public ProcurementSummaryView(ProcurementSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}