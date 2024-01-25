using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementSelectBottomSheetView : BottomSheet
{

	ProcurementSelectBottomSheetViewModel _viewModel;
	public ProcurementSelectBottomSheetView(ProcurementSelectBottomSheetViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}