using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;

public partial class DispatchByPurchaseOrderChangeBottomSheetView : BottomSheet
{
	DispatchByPurchaseOrderChangeViewModel _viewModel;
	public DispatchByPurchaseOrderChangeBottomSheetView(DispatchByPurchaseOrderChangeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}