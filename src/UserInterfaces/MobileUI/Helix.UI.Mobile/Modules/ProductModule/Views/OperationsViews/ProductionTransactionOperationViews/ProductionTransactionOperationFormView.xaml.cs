using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;

public partial class ProductionTransactionOperationFormView : ContentPage
{
	ProductionTransactionOperationFormViewModel _viewModel;
    public ProductionTransactionOperationFormView(ProductionTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}