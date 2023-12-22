using AndroidX.Lifecycle;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;

public partial class ProductionTransactionOperationView : ContentPage
{
	ProductionTransactionOperationView _viewModel;
    public ProductionTransactionOperationView(ProductionTransactionOperationView viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}