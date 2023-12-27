using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;

public partial class ProductionTransactionOperationViewModel : BaseViewModel
{
    public ProductionTransactionOperationViewModel()
    {
        Title = "Üretimden Giriş İşlemleri";
    }
    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}");
    }
}
