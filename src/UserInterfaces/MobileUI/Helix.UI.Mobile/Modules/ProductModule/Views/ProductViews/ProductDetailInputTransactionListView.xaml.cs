using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;

public partial class ProductDetailInputTransactionListView : ContentPage
{
	ProductDetailInputTransactionListViewModel _viewModel;
	public ProductDetailInputTransactionListView(ProductDetailInputTransactionListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}