using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;

namespace Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;

public partial class ReturnPurchaseListView : ContentPage
{
	ReturnPurchaseListViewModel _viewModel;
    public ReturnPurchaseListView(ReturnPurchaseListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=_viewModel = viewModel;
	}
}