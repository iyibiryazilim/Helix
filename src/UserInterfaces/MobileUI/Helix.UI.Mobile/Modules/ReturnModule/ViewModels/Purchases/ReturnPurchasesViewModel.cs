﻿using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases
{
	public partial class ReturnPurchasesViewModel : BaseViewModel
	{
        public ReturnPurchasesViewModel()
        {
			Title = "Satınalma İade İşlemleri";
		}
        [RelayCommand]
        async Task GoToReturnByPurchaseDispatchTransactionCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionSupplierView)}");
        }
    }
}
