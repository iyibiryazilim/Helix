using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.PurchaseOrderViews;

public partial class PurchaseOrderLineListView : ContentPage
{
	PurchaseOrderLineListViewModel _viewModel;
	public PurchaseOrderLineListView(PurchaseOrderLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}