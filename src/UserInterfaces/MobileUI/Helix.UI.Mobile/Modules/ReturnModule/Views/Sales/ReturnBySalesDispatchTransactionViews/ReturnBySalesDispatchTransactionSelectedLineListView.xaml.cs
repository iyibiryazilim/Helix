using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionSelectedLineListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionSelectedLineListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionSelectedLineListView(ReturnBySalesDispatchTransactionSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}