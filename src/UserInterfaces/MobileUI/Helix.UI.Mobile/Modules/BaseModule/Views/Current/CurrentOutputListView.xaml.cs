using Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Views.Current;

public partial class CurrentOutputListView : ContentPage
{
	CurrentOutputListViewModel _viewModel;
	public CurrentOutputListView(CurrentOutputListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}