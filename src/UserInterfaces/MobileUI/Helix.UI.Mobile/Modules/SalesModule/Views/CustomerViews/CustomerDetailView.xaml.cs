using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;

public partial class CustomerDetailView : ContentPage
{
	CustomerDetailViewModel _viewModel;
	public CustomerDetailView(CustomerDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}