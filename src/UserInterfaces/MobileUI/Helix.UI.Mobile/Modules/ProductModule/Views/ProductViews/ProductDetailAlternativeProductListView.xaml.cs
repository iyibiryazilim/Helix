using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailAlternativeProductListView : ContentPage
{
	private readonly ProductDetailAlternativeProductListViewModel _viewModel;
	public ProductDetailAlternativeProductListView(ProductDetailAlternativeProductListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}