using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

public partial class DispatchBySalesOrderFicheViewModel :BaseViewModel
{
    public DispatchBySalesOrderFicheViewModel()
    {
        Title = "Fiş Model";
    }
    [RelayCommand]
    async Task GoToSalesOrderLineList()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineListView)}");
    }
}
