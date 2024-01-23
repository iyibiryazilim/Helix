using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionLineViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;

public partial class ReturnByPurchaseDispatchTransactionLineLineChangeBottomSheetView : BottomSheet
{
	ReturnByPurchaseDispatchTransactionLineLineChangeViewModel _viewModel;

	public ReturnByPurchaseDispatchTransactionLineLineChangeBottomSheetView(ReturnByPurchaseDispatchTransactionLineLineChangeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}