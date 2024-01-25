using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionLineChangeBottomSheetView : BottomSheet
{
	ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineChangeBottomSheetView(ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}