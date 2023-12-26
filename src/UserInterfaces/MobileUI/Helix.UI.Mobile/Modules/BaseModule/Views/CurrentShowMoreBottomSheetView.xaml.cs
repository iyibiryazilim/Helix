using Helix.UI.Mobile.Modules.BaseModule.ViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.BaseModule.Views;

public partial class CurrentShowMoreBottomSheetView : BottomSheet
{
	CurrentShowMoreBottomSheetViewModel _viewModel;
	public CurrentShowMoreBottomSheetView(CurrentShowMoreBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
	async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		await this.DismissAsync();
	}
}