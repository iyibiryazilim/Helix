using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;

public partial class SupplierDetailView : ContentPage
{
	SupplierDetailViewModel _viewModel;
	public SupplierDetailView(SupplierDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}