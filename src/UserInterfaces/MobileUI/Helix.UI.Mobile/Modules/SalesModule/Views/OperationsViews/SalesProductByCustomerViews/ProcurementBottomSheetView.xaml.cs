using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;
using The49.Maui.BottomSheet;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementBottomSheetView : BottomSheet
{
	ProcurementBottomSheetViewModel _viewModel;
    public ProcurementBottomSheetView(ProcurementBottomSheetViewModel viewModel )
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

    }

    //async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    await this.DismissAsync();
    //}
}