using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;

public partial class OutCountingTransactionOperationViewModel: BaseViewModel
{
    public OutCountingTransactionOperationViewModel()
    {
        Title = "Sayım Eksikliği İşlemleri";
    }

    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}");
    }
}
