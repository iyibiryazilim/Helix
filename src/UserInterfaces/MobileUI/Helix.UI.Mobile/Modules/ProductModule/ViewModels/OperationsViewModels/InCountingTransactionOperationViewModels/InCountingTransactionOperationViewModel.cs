using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;

public partial class InCountingTransactionOperationViewModel :BaseViewModel
{
    public InCountingTransactionOperationViewModel()
    {
        Title = "Sayım Fazlası İşlemleri";
    }
    [RelayCommand]
    public async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}");
    }
}
