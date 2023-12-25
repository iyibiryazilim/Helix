using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailOutputReturnListView : ContentPage
{
	ProductDetailOutputReturnListViewModel _viewModel;
	public ProductDetailOutputReturnListView(ProductDetailOutputReturnListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}