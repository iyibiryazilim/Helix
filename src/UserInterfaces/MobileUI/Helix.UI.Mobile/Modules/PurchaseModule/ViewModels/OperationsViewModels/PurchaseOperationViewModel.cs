using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels
{
	public partial class PurchaseOperationViewModel : BaseViewModel
	{
        public PurchaseOperationViewModel()
        {
            Title = "Mal Kabul İşlemleri";
        }

        [RelayCommand]
        async Task GoToDispatchByOrderAsync()
        {
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderSupplierView)}");
		}
	}
}
