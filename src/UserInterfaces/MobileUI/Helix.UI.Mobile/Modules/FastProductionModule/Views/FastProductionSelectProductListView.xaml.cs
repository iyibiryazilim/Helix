using Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

namespace Helix.UI.Mobile.Modules.FastProductionModule.Views;

public partial class FastProductionSelectProductListView : ContentPage
{
	FastProductionSelectProductListViewModel _viewModel;
	public FastProductionSelectProductListView(FastProductionSelectProductListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}