using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class ProductOperationView : ContentPage
{
    ProductOperationViewModel _viewModel;
    public ProductOperationView(ProductOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}