using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderFormView : ContentPage
{
	DispatchBySalesOrderFormViewModel _viewModel;
    public DispatchBySalesOrderFormView(DispatchBySalesOrderFormViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}