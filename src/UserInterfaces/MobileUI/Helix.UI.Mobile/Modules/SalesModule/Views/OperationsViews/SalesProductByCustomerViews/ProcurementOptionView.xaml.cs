using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementOptionView : ContentPage
{
	ProcurementOption _viewModel;
    public ProcurementOptionView(ProcurementOption viewModel)
	{
		InitializeComponent();

		BindingContext = _viewModel = viewModel;

	}
}