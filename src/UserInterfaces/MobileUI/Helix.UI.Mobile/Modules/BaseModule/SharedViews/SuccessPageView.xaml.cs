using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SuccessPageView : ContentPage
{
	SuccessPageViewModel _viewModel;
	public SuccessPageView(SuccessPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}