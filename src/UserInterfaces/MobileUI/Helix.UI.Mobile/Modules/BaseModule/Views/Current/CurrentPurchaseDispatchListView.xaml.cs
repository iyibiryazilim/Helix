using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentPurchaseDispatchListView : ContentPage
{
	CurrentPurchaseDispatchListViewModel _viewModel;
	public CurrentPurchaseDispatchListView(CurrentPurchaseDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}