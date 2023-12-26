using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailInputReturnListView : ContentPage
{
	ProductDetailInputReturnListViewModel _viewModel;
	public ProductDetailInputReturnListView(ProductDetailInputReturnListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}