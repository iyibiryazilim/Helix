using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentPurchaseReturnListView : ContentPage
{
	CurrentPurchaseReturnListViewModel _viewModel;
	public CurrentPurchaseReturnListView(CurrentPurchaseReturnListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}