using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentSalesOrderListView : ContentPage
{
	CurrentSalesOrderListViewModel _viewModel;
	public CurrentSalesOrderListView(CurrentSalesOrderListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}