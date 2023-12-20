using Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.PanelViews;

public partial class SalesPanelView : ContentPage
{
	SalesPanelViewModel _viewModel;
	public SalesPanelView(SalesPanelViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}