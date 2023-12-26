using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentPurchaseOrderListView : ContentPage
{
	CurrentPurchaseOrderListViewModel _viewModel;
	public CurrentPurchaseOrderListView(CurrentPurchaseOrderListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}