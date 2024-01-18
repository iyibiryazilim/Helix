using AndroidX.Lifecycle;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;

public partial class SalesProductWarehouseSelectView : ContentPage
{
	SalesProductWarehouseSelectViewModel _viewModel;
    public SalesProductWarehouseSelectView(SalesProductWarehouseSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}