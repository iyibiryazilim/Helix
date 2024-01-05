using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;

public partial class PurchaseDispatchFormView : ContentPage
{
    PurchaseDispatchFormViewModel _viewModel;
	public PurchaseDispatchFormView(PurchaseDispatchFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}