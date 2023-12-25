using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;

public partial class ProductTransactionBottomSheetView : BottomSheet
{
	ProductTransactionBottomSheetViewModel _viewModel;
	public ProductTransactionBottomSheetView(ProductTransactionBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}