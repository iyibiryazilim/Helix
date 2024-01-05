using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineFormViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineFormView;

public partial class DispatchBySalesOrderLineFormView : ContentPage
{
	DispatchBySalesOrderLineFormViewModel _viewModel;
    public DispatchBySalesOrderLineFormView(DispatchBySalesOrderLineFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=_viewModel=viewModel;
	}
}