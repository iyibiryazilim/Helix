using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
	public partial class ReturnByPurchaseDispatchTransactionLineChangeViewModel : BaseViewModel
	{
		[ObservableProperty]
		DispatchTransactionLineGroup lineGroup;
	}
}
