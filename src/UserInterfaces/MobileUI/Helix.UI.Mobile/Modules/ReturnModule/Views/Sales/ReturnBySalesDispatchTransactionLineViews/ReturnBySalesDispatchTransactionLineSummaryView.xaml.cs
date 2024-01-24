using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineSummaryView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineSummaryViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineSummaryView(ReturnBySalesDispatchTransactionLineSummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}