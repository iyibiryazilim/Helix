using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;

public partial class ReturnPurchaseFormView : ContentPage
{
	ReturnPurchaseFormViewModel _viewModel;
    public ReturnPurchaseFormView(ReturnPurchaseFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}