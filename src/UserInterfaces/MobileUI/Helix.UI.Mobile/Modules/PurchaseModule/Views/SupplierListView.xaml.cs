using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views;

public partial class SupplierListView : ContentPage
{
	SupplierListViewModel _viewModel;
	public SupplierListView(SupplierListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}