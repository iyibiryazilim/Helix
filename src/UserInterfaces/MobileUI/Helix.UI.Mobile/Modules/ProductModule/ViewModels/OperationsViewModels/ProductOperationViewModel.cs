using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels;

public partial class ProductOperationViewModel :BaseViewModel
{
    public ProductOperationViewModel()
    {
        Title = "Malzeme İşlemleri";
    }

    [RelayCommand]
    async Task GoToInCounting()
    {
        await Shell.Current.GoToAsync($"{nameof(InCountingTransactionOperationView)}");
    }

    [RelayCommand]
    async Task GoToOutCounting()
    {
        await Shell.Current.GoToAsync($"{nameof(OutCountingTransactionOperationView)}");
    }

    [RelayCommand]
    async Task GoToProductionOperation()
    {
        await Shell.Current.GoToAsync($"{nameof(ProductionTransactionOperationView)}");
    }

    [RelayCommand]
    async Task GoToConsumableTransaction()
    {
        await Shell.Current.GoToAsync($"{nameof(ConsumableTransactionOperationView)}");
    }


    [RelayCommand]
    async Task GoToWastageTransaction()
    {
        await Shell.Current.GoToAsync($"{nameof(WastageTransactionOperationView)}");
    }

}