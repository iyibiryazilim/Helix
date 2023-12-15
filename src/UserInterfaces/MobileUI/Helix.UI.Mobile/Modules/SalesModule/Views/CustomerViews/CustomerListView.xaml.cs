using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;

public partial class CustomerListView : ContentPage
{
	private CustomerListViewModel _viewModel;
	public CustomerListView(CustomerListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}