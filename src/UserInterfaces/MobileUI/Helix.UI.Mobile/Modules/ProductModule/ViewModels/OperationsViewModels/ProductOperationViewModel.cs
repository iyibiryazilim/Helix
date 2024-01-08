using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

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

    [RelayCommand]
    async Task GoToWarehouseTransferOperationViewAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            await Shell.Current.GoToAsync($"{nameof(WarehouseTransferOperationView)}");
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
        }
        finally
        {
			IsBusy = false;
        }
    }

}