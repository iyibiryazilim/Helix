using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;

public partial class ReturnByPurchaseDispatchTransactionLineChangeBottomSheetView : BottomSheet
{
	ReturnByPurchaseDispatchTransactionLineChangeViewModel _viewModel;
	public ReturnByPurchaseDispatchTransactionLineChangeBottomSheetView(ReturnByPurchaseDispatchTransactionLineChangeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}