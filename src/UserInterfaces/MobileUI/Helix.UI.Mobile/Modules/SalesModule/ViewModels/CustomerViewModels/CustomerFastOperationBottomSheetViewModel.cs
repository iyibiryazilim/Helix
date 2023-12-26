using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	public partial class CustomerFastOperationBottomSheetViewModel : BaseViewModel
    {
        [ObservableProperty]
        Current current;
        public CustomerFastOperationBottomSheetViewModel()
        {
            
        }
    }
}
