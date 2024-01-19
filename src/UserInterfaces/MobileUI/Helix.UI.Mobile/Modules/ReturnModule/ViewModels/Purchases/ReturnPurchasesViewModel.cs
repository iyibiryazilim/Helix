using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases
{
	public partial class ReturnPurchasesViewModel : BaseViewModel
	{
        public ReturnPurchasesViewModel()
        {
			Title = "Satın Alma İade İşlemleri";
		}
        [RelayCommand]
        async Task GoToReturnByPurchaseDispatchTransactionCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionSupplierView)}");
        }

        [RelayCommand]
        async Task GoToReturnPurchaseSelectWarehouse()
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnPurchaseSelectWarehouseView)}");
        }
		[RelayCommand]
		async Task GoToReturnPurchaseSelectSupplierByLine()
		{
			try
			{
				await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionLineSupplierView)}");

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				throw;
			}
		}
	}
}
