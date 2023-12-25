using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailSalesOrderListView : ContentPage
{
	ProductDetailSalesOrderListViewModel _viewModel;
	public ProductDetailSalesOrderListView(ProductDetailSalesOrderListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}