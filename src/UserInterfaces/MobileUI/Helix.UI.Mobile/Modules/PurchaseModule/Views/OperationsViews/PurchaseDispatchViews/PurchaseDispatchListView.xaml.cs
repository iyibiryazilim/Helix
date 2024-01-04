using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;

public partial class PurchaseDispatchListView : ContentPage
{
	PurchaseDispatchListViewModel _viewModel;
	public PurchaseDispatchListView(PurchaseDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}