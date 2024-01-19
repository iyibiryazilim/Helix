using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineSelectedLineListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineSelectedLineListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineSelectedLineListView(ReturnBySalesDispatchTransactionLineSelectedLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}