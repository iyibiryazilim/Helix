using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailSalesDispatchListView : ContentPage
{
	ProductDetailSalesDispatchListViewModel _viewModel;
	public ProductDetailSalesDispatchListView(ProductDetailSalesDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}