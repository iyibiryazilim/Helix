using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;

public partial class WarehouseCountingSelectProductsView : ContentPage
{
	WarehouseCountingSelectProductsViewModel _viewModel;
	public WarehouseCountingSelectProductsView(WarehouseCountingSelectProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
}