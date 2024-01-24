using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionSummaryView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionSummaryViewModel _viewModel;
	public ReturnBySalesDispatchTransactionSummaryView(ReturnBySalesDispatchTransactionSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}