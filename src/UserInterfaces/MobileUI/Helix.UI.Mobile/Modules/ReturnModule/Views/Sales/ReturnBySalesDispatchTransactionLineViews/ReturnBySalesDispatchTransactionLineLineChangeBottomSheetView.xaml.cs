using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineLineChangeBottomSheetView : BottomSheet
{
	private readonly ReturnBySalesDispatchTransactionLineLineChangeBottomSheetViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineLineChangeBottomSheetView(ReturnBySalesDispatchTransactionLineLineChangeBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}