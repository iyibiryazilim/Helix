using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;

public partial class SupplierListView : ContentPage
{
    SupplierListViewModel _viewModel;
    public SupplierListView(SupplierListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}