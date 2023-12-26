using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

public partial class DispatchBySalesOrderLineListViewModel:BaseViewModel
{
    public DispatchBySalesOrderLineListViewModel()
    {
        Title = "Line List";
    }
    [RelayCommand]
    async Task GoToSalesOrderSummary()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderSummaryView)}");
    }

}
