using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineCustomerView : ContentPage
{
	readonly DispatchBySalesOrderLineCustomerViewModel _viewModel;
	public DispatchBySalesOrderLineCustomerView(DispatchBySalesOrderLineCustomerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}