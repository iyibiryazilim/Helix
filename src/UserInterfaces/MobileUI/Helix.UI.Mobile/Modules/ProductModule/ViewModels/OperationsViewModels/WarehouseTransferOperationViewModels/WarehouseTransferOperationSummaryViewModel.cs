using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;



[QueryProperty(name: nameof(WarehouseTotal), queryId: nameof(WarehouseTotal))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]

public partial class WarehouseTransferOperationSummaryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<WarehouseTotal> warehouseTotal;

	[ObservableProperty]
	Warehouse warehouse;

	public WarehouseTransferOperationSummaryViewModel()
	{
		Title = "Transfer Özeti";
	}
}
