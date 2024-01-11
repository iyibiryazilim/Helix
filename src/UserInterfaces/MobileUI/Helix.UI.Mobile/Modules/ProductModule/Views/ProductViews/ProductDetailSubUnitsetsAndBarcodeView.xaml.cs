using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailSubUnitsetsAndBarcodeView : ContentPage
{
	private readonly ProductDetailSubUnitsetsAndBarcodeViewModel _viewModel;
    public ProductDetailSubUnitsetsAndBarcodeView(ProductDetailSubUnitsetsAndBarcodeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=_viewModel = viewModel;
	}
}