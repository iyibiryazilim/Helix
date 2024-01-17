using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;

public partial class WarehouseCountingSummaryView : ContentPage
{
	WarehouseCountingSummaryViewModel _viewModel;
	public WarehouseCountingSummaryView(WarehouseCountingSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}