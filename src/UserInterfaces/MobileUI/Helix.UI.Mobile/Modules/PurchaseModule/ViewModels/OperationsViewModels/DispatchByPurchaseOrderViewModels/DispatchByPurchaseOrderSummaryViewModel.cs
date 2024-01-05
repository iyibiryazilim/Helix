using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(WaitingOrderLine), nameof(WaitingOrderLine))]

	public partial class DispatchByPurchaseOrderSummaryViewModel : BaseViewModel
    {
		[ObservableProperty]
		List<WaitingOrderLine> waitingOrderLine; 
	}
}
