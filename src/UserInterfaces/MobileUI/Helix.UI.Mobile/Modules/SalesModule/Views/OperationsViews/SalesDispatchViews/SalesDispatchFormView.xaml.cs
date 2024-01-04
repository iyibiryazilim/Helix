using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

namespace Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
public partial class SalesDispatchFormView : ContentPage
{
	SalesDispatchFormViewModel _viewModel;
	public SalesDispatchFormView(SalesDispatchFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}