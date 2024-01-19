using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineLineListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineLineListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineLineListView(ReturnBySalesDispatchTransactionLineLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}