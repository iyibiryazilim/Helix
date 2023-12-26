using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;

public partial class DispatchBySalesOrderFicheView : ContentPage
{
	DispatchBySalesOrderFicheViewModel _viewModel;
    public DispatchBySalesOrderFicheView(DispatchBySalesOrderFicheViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}