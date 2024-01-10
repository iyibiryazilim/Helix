using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionCustomerView : ContentPage
{
	ReturnBySalesDispatchTransactionCustomerViewModel _viewModel;
    public ReturnBySalesDispatchTransactionCustomerView(ReturnBySalesDispatchTransactionCustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}