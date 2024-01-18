using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;

public partial class WarehouseCountingListView : ContentPage
{
	WarehouseCountingListViewModel _viewModel;
	public WarehouseCountingListView(WarehouseCountingListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}