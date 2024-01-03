using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class FailedPageView : ContentPage
{
	FailedPageViewModel _viewModel;
	public FailedPageView(FailedPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}