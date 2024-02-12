using Helix.UI.Mobile.Modules.PanelModule.ViewModels;

namespace Helix.UI.Mobile.Modules.PanelModule.Views;

public partial class ProfilePageView : ContentPage
{
	ProfilePageViewModel _viewModel;
    public ProfilePageView(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}