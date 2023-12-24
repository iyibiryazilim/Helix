using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseDetailInputTransactionView : ContentPage
{
	private WarehouseDetailInputTransactionViewModel _viewModel;
	public WarehouseDetailInputTransactionView(WarehouseDetailInputTransactionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}