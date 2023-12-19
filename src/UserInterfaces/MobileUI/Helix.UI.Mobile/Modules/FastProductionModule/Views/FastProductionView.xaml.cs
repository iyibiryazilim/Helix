using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

namespace Helix.UI.Mobile.Modules.FastProductionModule.Views;

public partial class FastProductionView : ContentPage
{
	FastProductionViewModel _viewModel;
	public FastProductionView(FastProductionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel; 
	}
}