using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;

public partial class PurchaseDispatchSelectWarehouseView : ContentPage
{
	PurchaseDispatchSelectWarehouseViewModel _viewModel;
	public PurchaseDispatchSelectWarehouseView(PurchaseDispatchSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}