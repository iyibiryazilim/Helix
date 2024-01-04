using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;

public partial class SalesDispatchListView : ContentPage
{
	SalesDispatchListViewModel _viewModel;
	public SalesDispatchListView(SalesDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}