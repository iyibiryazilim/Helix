using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderCustomerView : ContentPage
{
	DispatchBySalesOrderCustomerViewModel _viewModel;
    public DispatchBySalesOrderCustomerView(DispatchBySalesOrderCustomerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}