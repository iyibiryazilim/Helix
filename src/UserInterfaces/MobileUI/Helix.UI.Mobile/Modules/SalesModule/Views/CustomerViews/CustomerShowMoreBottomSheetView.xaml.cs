using Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;

public partial class CustomerShowMoreBottomSheetView : BottomSheet
{
	CustomerShowMoreBottomSheetViewModel _viewModel;
	public CustomerShowMoreBottomSheetView(CustomerShowMoreBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= _viewModel = viewModel;
	}
	async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		await this.DismissAsync();
	}
}