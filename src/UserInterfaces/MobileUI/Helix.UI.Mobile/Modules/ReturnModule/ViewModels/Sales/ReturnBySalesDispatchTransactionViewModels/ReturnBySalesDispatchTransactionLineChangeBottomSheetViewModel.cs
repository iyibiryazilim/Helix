using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels
{
    public partial class ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel : BaseViewModel
    {
        [ObservableProperty]
        DispatchTransactionLineGroup dispatchTransactionLineGroupList;

        public ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel()
        {
            
        }
    }
}
