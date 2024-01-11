namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailWarehouseTotalView : ContentPage
{
	private readonly ProductDetailWarehouseTotalView _viewModel;
	public ProductDetailWarehouseTotalView(ProductDetailWarehouseTotalView viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}