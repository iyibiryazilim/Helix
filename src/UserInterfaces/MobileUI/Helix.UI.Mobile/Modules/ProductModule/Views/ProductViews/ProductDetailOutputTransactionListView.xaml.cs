using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailOutputTransactionListView : ContentPage
{
	ProductDetailOutputTransactionListViewModel _viewModel;
	public ProductDetailOutputTransactionListView(ProductDetailOutputTransactionListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}