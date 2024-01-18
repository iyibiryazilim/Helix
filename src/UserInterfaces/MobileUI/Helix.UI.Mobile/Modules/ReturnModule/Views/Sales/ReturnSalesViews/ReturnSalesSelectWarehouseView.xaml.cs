using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;

public partial class ReturnSalesSelectWarehouseView : ContentPage
{
	ReturnSalesSelectWarehouseViewModel _viewModel;
    public ReturnSalesSelectWarehouseView(ReturnSalesSelectWarehouseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}