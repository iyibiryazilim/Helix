using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;

public partial class WastageTransactionOperationFormView : ContentPage
{
    WastageTransactionOperationFormViewModel _viewModel;
    public WastageTransactionOperationFormView(WastageTransactionOperationFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}