using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailCustomerAndSupplierListView : ContentPage
{
	private readonly ProductDetailCustomerAndSupplierListViewModel _viewModel;
	public ProductDetailCustomerAndSupplierListView(ProductDetailCustomerAndSupplierListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}