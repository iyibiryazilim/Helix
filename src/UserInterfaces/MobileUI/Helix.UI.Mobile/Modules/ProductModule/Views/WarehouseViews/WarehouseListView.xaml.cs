using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseListView : ContentPage
{
    private WarehouseListViewModel _viewModel;
    public WarehouseListView(WarehouseListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}