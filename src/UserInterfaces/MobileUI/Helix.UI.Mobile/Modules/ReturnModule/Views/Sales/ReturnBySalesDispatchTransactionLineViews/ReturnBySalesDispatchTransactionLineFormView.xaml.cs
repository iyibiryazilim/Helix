using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;

public partial class ReturnBySalesDispatchTransactionLineFormView : ContentPage
{
	private readonly ReturnBySalesDispatchTransactionLineFormViewModel _viewModel;
	public ReturnBySalesDispatchTransactionLineFormView(ReturnBySalesDispatchTransactionLineFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}