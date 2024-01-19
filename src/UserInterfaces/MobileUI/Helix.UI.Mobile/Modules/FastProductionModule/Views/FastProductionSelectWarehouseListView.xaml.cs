using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

namespace Helix.UI.Mobile.Modules.FastProductionModule.Views;

public partial class FastProductionSelectWarehouseListView : ContentPage
{
	FastProductionSelectWarehouseListViewModel _viewModel;
	public FastProductionSelectWarehouseListView(FastProductionSelectWarehouseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}