using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;

public partial class WarehouseCountingFormView : ContentPage
{
	private readonly WarehouseCountingFormViewModel _viewModel;
	public WarehouseCountingFormView(WarehouseCountingFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;	
	}
}