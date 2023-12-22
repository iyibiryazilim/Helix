using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseDetailView : ContentPage
{
	private readonly WarehouseDetailViewModel _viewModel;
	public WarehouseDetailView(WarehouseDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}