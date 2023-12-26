using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

public partial class DispatchBySalesOrderSummaryViewModel:BaseViewModel
{
    public DispatchBySalesOrderSummaryViewModel()
    {
        Title = "Özet";
    }
    [RelayCommand]
    async Task GoToSalesOrderForm()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderFormView)}");
    }
}
