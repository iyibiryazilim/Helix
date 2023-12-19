using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views;

public partial class PurchaseOrderListView : ContentPage
{
	PurchaseOrderListViewModel _viewModel;
	public PurchaseOrderListView(PurchaseOrderListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}