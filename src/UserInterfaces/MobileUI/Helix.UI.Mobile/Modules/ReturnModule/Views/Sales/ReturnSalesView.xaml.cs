using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Sales;

public partial class ReturnSalesView : ContentPage
{
	ReturnSalesViewModel _viewModel;
	public ReturnSalesView(ReturnSalesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}