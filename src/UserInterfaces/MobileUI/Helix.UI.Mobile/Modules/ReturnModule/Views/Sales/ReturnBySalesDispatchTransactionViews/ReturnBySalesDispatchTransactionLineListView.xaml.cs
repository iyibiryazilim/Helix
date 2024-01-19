using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionLineListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineListView(ReturnBySalesDispatchTransactionLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}