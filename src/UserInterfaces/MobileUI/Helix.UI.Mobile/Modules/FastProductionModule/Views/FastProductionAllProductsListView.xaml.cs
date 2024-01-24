using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

namespace Helix.UI.Mobile.Modules.FastProductionModule.Views;

public partial class FastProductionAllProductsListView : ContentPage
{
	FastProductionAllProductsListViewModel _viewModel;
	public FastProductionAllProductsListView(FastProductionAllProductsListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}