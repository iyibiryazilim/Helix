using Helix.UI.Mobile.Modules.PanelModule.ViewModels;

namespace Helix.UI.Mobile.Modules.PanelModule.Views;

public partial class PanelView : ContentPage
{
	PanelViewModel _viewModel;
	public PanelView(PanelViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}