using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views;

public partial class PurchaseOrderLineListView : ContentPage
{
	PurchaseOrderLineLineListViewModel _viewModel;
	public PurchaseOrderLineListView(PurchaseOrderLineLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}