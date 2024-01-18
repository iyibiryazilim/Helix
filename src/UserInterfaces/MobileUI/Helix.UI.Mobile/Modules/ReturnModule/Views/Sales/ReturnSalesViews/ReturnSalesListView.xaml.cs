using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;

public partial class ReturnSalesListView : ContentPage
{
	ReturnSalesListViewModel _viewModel;
    public ReturnSalesListView(ReturnSalesListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;

    }
}