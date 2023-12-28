using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;

public partial class SupplierFastOperationBottomSheetView : BottomSheet
{
	SupplierFastOperationBottomSheetViewModel _viewModel;
	public SupplierFastOperationBottomSheetView(SupplierFastOperationBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
	async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		await this.DismissAsync();
	}
}