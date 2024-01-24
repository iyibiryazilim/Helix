using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;

public partial class DispatchByPurchaseOrderLineChangeBottomSheetView : BottomSheet
{
	DispatchByPurchaseOrderLineChangeViewModel _viewModel;
	public DispatchByPurchaseOrderLineChangeBottomSheetView(DispatchByPurchaseOrderLineChangeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}