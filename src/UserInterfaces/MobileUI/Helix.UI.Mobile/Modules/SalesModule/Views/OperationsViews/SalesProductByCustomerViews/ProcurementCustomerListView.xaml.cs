using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementCustomerListView : ContentPage
{
    ProcurementCustomerListViewModel _viewModel;
	public ProcurementCustomerListView(ProcurementCustomerListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}


}