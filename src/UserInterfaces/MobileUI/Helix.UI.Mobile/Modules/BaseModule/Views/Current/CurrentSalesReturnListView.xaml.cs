using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentSalesReturnListView : ContentPage
{
	CurrentSalesReturnListViewModel _viewModel;
	public CurrentSalesReturnListView(CurrentSalesReturnListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}