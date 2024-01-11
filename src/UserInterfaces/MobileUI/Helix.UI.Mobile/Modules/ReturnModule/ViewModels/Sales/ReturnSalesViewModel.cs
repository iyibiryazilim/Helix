using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

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

    }
}
