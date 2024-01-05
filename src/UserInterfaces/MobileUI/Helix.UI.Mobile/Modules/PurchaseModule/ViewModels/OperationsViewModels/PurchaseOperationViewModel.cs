using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.PurchaseDispatchViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

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
		[RelayCommand]
		async Task GoToDispatchByOrderLineAsync()
		{
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineSupplierView)}");
		}
		[RelayCommand]
        async Task GoToPurchaseDispatchListViewAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync($"{nameof(PurchaseDispatchListView)}");
            }
            catch(Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            finally
            {
				IsBusy = false;
			}
        }
	}
}
