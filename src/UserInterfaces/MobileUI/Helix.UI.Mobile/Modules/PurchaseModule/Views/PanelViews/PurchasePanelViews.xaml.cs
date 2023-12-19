using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PanelViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.PanelViews;

public partial class PurchasePanelViews : ContentPage
{
	PurchasePanelViewModel _viewModel;
	public PurchasePanelViews(PurchasePanelViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}