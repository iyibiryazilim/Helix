using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseDetailProductListView : ContentPage
{
	private WarehouseDetailProductListViewModel _viewModel;
	public WarehouseDetailProductListView(WarehouseDetailProductListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}