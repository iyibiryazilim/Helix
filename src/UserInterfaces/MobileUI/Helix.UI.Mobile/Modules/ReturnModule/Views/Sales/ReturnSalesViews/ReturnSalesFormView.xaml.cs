using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;

public partial class ReturnSalesFormView : ContentPage
{
	ReturnSalesFormViewModel _viewModel;
    public ReturnSalesFormView(ReturnSalesFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}