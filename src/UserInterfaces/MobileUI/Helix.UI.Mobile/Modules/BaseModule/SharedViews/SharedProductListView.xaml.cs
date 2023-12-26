using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SharedProductListView : ContentPage
{
	SharedProductListViewModel _viewModel;
    public SharedProductListView(SharedProductListViewModel viewModel)
	{

		InitializeComponent();
		BindingContext = _viewModel = viewModel;

    }
}