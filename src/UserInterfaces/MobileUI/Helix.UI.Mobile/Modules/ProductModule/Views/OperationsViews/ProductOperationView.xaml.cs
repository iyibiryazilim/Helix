using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class ProductOperationView : ContentPage
{
    ProductOperationView _viewModel;
    public ProductOperationView(ProductOperationView viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}