using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class ProcurementSelectWarehouseView : ContentPage
{
	ProcurementSelectWarehouseViewModel _viewModel;
    public ProcurementSelectWarehouseView(ProcurementSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}