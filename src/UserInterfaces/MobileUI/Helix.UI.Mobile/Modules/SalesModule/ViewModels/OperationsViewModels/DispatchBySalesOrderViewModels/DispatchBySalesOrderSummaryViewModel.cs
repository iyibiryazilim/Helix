using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels;

[QueryProperty(nameof(ChangedLines), nameof(ChangedLines))]
[QueryProperty(nameof(Current), nameof(Current))]
[QueryProperty(nameof(Warehouse), nameof(Warehouse))]


public partial class DispatchBySalesOrderSummaryViewModel : BaseViewModel
{
    public DispatchBySalesOrderSummaryViewModel()
    {
        Title = "Özet";
        GetDataCommand = new Command(async () => await LoadData());
    }

    public Command GetDataCommand { get; }

    [ObservableProperty]
    ObservableCollection<WaitingOrderLine> changedLines;
    [ObservableProperty]
    Customer current;

    [ObservableProperty]
    Warehouse warehouse;

    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            await Task.Delay(500);
            await MainThread.InvokeOnMainThreadAsync(GetCurrentAsync);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    async Task GetCurrentAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            Current = new Customer()
            {
                Code = ChangedLines.First().CurrentCode,
                Name = ChangedLines.First().CurrentName
            };

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GoToSalesOrderForm()
    {
        await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderFormView)}", new Dictionary<string, object>
        {
            ["SelectedOrderLines"] = ChangedLines,
            ["Warehouse"] = Warehouse,
            ["Current"] = Current,
        });
    }
}
