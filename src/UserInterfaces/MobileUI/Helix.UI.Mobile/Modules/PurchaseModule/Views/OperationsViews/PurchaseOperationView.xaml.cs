using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews;

public partial class PurchaseOperationView : ContentPage
{
	PurchaseOperationViewModel _viewModel;
	public PurchaseOperationView(PurchaseOperationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}