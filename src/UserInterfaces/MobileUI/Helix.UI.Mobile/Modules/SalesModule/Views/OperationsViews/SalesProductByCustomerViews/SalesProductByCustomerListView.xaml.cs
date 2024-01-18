using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class SalesProductByCustomerListView : ContentPage
{
	SalesProductByCustomerListViewModel _viewModel;
    public SalesProductByCustomerListView(SalesProductByCustomerListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}