using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineLineChangeBottomSheetView : BottomSheet
{
	private readonly DispatchBySalesOrderLineLineChangeBottomSheetViewModel _viewModel;
	public DispatchBySalesOrderLineLineChangeBottomSheetView(DispatchBySalesOrderLineLineChangeBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}