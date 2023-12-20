using Helix.UI.Mobile.Modules.ProductModule.ViewModels.PanelViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.PanelViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.PanelViews;

public partial class ProductPanelView : ContentPage
{
    ProductPanelViewModel _viewModel;
    public ProductPanelView(ProductPanelViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}