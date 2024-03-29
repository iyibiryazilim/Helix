﻿using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnSalesViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales
{
	public partial class ReturnSalesViewModel : BaseViewModel
	{
        public ReturnSalesViewModel()
        {
            Title = "Satış İade İşlemleri";
        }

        
        [RelayCommand]
        async Task GoToReturnBySalesDispatchTransactionCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionCustomerView)}");
        }
        [RelayCommand]
        async Task GoToReturnSalesSelectWarehouse()
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnSalesSelectWarehouseView)}");
        }

        [RelayCommand]
        async Task GoToReturnBySalesDispatchTransactionLineCustomerViewAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionLineCustomerView)}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
				IsBusy = false;
			}
            
        }

    }
}
