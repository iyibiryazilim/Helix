using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews.WarehouseCountingViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
[QueryProperty(name: nameof(SelectedProducts), queryId: nameof(SelectedProducts))]
public partial class WarehouseCountingSummaryViewModel : BaseViewModel
{

    [ObservableProperty]
    Warehouse selectedWarehouse;

    [ObservableProperty]
    public ObservableCollection<WarehouseTotal> selectedProducts;



    public WarehouseCountingSummaryViewModel()
    {
        Title = "Ambar Sayım Özeti";
    }

    [RelayCommand]
    async Task GoToFormViewAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            await Shell.Current.GoToAsync($"{nameof(WarehouseCountingFormView)}", new Dictionary<string, object>
            {
                ["Warehouse"] = SelectedWarehouse,
                ["SelectedProducts"] = SelectedProducts,
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
