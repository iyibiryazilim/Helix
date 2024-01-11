using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineCustomerView : ContentPage
{
	ReturnBySalesDispatchTransactionLineCustomerViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineCustomerView(ReturnBySalesDispatchTransactionLineCustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}