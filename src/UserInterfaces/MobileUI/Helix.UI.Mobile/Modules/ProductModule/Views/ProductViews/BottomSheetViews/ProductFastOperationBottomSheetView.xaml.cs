using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;

public partial class ProductFastOperationBottomSheetView : BottomSheet
{
	ProductFastOperationBottomSheetViewModel _viewModel;
	public ProductFastOperationBottomSheetView(ProductFastOperationBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		await this.DismissAsync();
	}
}