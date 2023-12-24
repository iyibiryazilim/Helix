using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class ProductionTransactionOperationView : ContentPage
{
	ProductionTransactionOperationViewModel _viewModel;
    public ProductionTransactionOperationView(ProductionTransactionOperationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}