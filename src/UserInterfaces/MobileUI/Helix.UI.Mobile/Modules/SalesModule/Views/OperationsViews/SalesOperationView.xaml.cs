using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews;

public partial class SalesOperationView : ContentPage
{
	SalesOperationViewModel _viewModel;
	public SalesOperationView(SalesOperationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}