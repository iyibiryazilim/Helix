using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentSalesDispatchListView : ContentPage
{
	CurrentSalesDispatchListViewModel _viewModel;
	public CurrentSalesDispatchListView(CurrentSalesDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}