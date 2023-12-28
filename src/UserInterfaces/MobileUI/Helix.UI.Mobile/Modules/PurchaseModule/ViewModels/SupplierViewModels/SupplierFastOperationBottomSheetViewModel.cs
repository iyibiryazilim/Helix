using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels
{
	public partial class SupplierFastOperationBottomSheetViewModel : BaseViewModel
	{
		[ObservableProperty]
		Current current;
	}
}
