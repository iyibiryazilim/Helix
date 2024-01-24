using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderLineChangeBottomSheetView : BottomSheet
{
	private readonly DispatchBySalesOrderLineChangeBottomSheetViewModel _viewModel;
	public DispatchBySalesOrderLineChangeBottomSheetView(DispatchBySalesOrderLineChangeBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}