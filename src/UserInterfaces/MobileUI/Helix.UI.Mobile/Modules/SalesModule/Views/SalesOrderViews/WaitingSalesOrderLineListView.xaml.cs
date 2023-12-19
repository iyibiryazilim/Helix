using Helix.UI.Mobile.Modules.SalesModule.ViewModels.SalesOrderViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.SalesOrderViews;

public partial class WaitingSalesOrderLineListView : ContentPage
{
	WaitingSalesOrderLineListViewModel _viewModel;
	public WaitingSalesOrderLineListView(WaitingSalesOrderLineListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}