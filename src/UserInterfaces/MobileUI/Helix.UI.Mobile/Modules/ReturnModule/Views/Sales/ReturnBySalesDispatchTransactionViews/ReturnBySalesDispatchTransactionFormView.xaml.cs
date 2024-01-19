using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;

public partial class ReturnBySalesDispatchTransactionFormView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionFormViewModel _viewModel;
	public ReturnBySalesDispatchTransactionFormView(ReturnBySalesDispatchTransactionFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

	}
}