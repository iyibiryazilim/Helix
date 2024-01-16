using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;

public partial class SalesDispatchWarehouseListView : ContentPage
{
	SalesDispatchWarehouseListViewModel _viewModel;
	public SalesDispatchWarehouseListView(SalesDispatchWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}