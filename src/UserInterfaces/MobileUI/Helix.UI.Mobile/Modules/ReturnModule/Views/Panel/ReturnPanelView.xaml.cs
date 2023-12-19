using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Panel;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Panel;

public partial class ReturnPanelView : ContentPage
{
	ReturnPanelViewModel _viewModel;
	public ReturnPanelView(ReturnPanelViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}