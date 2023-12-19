using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases;

public partial class ReturnPurchasesView : ContentPage
{
	ReturnPurchasesViewModel _viewModel;
	public ReturnPurchasesView(ReturnPurchasesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}