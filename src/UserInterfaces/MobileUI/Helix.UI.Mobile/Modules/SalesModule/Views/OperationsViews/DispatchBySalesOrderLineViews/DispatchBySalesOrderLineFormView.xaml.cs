using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;

public partial class DispatchBySalesOrderLineFormView : ContentPage
{
	DispatchBySalesOrderLineFormViewModel _viewModel;
    public DispatchBySalesOrderLineFormView(DispatchBySalesOrderLineFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=_viewModel=viewModel;
	}
}