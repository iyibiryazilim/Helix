using Helix.UI.Mobile.Modules.LoginModule.ViewModels.BottomSheetViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.LoginModule.Views.BottomSheetViews;

public partial class ConfigBottomSheetView : BottomSheet
{
	ConfigBottomSheetViewModel _viewModel;
	public ConfigBottomSheetView(ConfigBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
		await this.DismissAsync();
	}
}