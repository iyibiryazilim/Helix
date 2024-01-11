using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailWarehouseParametersView : ContentPage
{
	private readonly ProductDetailWarehouseParametersViewModel _viewModel;
	public ProductDetailWarehouseParametersView(ProductDetailWarehouseParametersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}