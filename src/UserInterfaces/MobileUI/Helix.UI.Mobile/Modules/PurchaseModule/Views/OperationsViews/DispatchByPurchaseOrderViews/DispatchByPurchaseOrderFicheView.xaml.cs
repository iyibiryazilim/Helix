using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderFicheView : ContentPage
{
	DispatchByPurchaseOrderFicheViewModel _viewModel;
	public DispatchByPurchaseOrderFicheView(DispatchByPurchaseOrderFicheViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}