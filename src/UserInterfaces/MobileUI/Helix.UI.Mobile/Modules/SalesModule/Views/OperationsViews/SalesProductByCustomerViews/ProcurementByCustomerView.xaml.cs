using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementByCustomerView : ContentPage
{
	ProcurementByCustomerViewModel _viewModel;
    public ProcurementByCustomerView(ProcurementByCustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}