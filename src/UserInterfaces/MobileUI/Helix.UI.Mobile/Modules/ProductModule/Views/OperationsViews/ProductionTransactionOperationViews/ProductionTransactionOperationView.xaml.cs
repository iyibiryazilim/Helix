using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;

public partial class ProductionTransactionOperationView : ContentPage
{
	ProductionTransactionOperationViewModel _viewModel;
    public ProductionTransactionOperationView(ProductionTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}