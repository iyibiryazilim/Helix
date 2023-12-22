using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailView : ContentPage
{
	ProductDetailViewModel _viewModel;
	public ProductDetailView(ProductDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}