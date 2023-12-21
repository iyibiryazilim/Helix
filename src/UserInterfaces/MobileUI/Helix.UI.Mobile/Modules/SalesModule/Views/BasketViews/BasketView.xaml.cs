using Helix.UI.Mobile.Modules.SalesModule.ViewModels.BasketViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.BasketViews;

public partial class BasketView : ContentPage
{
	private BasketViewModel _viewModel;
	public BasketView(BasketViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}