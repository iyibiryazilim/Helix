using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;

public partial class WarehouseDetailOutputTransactionView : ContentPage
{
	private WarehouseDetailOutputTransactionViewModel _viewModel;
	public WarehouseDetailOutputTransactionView(WarehouseDetailOutputTransactionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}