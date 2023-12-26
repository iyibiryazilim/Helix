using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailPurchaseDispatchListView : ContentPage
{
	ProductDetailPurchaseDispatchListViewModel _viewModel;
	public ProductDetailPurchaseDispatchListView(ProductDetailPurchaseDispatchListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}