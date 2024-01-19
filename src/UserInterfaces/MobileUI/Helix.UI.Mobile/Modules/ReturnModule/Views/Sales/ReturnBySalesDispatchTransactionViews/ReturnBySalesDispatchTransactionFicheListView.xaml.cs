using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionFicheListView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionFicheListViewModel _viewModel;
	public ReturnBySalesDispatchTransactionFicheListView(ReturnBySalesDispatchTransactionFicheListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}