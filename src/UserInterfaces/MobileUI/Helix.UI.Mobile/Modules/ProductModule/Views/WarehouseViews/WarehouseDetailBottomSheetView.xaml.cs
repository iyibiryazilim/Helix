using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseDetailBottomSheetView : BottomSheet
{
	WarehouseDetailBottomSheetViewModel _viewModel;
    public WarehouseDetailBottomSheetView(WarehouseDetailBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
		
	}
}