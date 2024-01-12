using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailWarehouseTotalView : ContentPage
{
	private readonly ProductDetailWarehouseTotalViewModel _viewModel;
	public ProductDetailWarehouseTotalView(ProductDetailWarehouseTotalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}