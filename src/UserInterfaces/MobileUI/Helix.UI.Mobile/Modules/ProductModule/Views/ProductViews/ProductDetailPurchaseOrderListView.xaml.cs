using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailPurchaseOrderListView : ContentPage
{
	ProductDetailPurchaseOrderListViewModel _viewModel;
	public ProductDetailPurchaseOrderListView(ProductDetailPurchaseOrderListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}