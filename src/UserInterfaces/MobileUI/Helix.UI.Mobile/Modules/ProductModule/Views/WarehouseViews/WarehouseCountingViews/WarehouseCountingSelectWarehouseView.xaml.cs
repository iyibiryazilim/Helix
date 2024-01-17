using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;

public partial class WarehouseCountingSelectWarehouseView : ContentPage
{
	WarehouseCountingSelectWarehouseViewModel _viewModel;
	public WarehouseCountingSelectWarehouseView(WarehouseCountingSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}