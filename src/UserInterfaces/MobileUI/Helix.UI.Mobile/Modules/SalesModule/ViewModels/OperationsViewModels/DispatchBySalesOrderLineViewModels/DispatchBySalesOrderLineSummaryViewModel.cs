using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels
{
    [QueryProperty(nameof(SelectedOrderLines), nameof(SelectedOrderLines))]
    [QueryProperty(nameof(Current), nameof(Current))]
    [QueryProperty(nameof(Warehouse), nameof(Warehouse))]
    [QueryProperty(nameof(ShipInfo), nameof(ShipInfo))]
    public partial class DispatchBySalesOrderLineSummaryViewModel : BaseViewModel
	{
        public DispatchBySalesOrderLineSummaryViewModel()
        {
            Title = "Özet";
            GetDataCommand = new Command(async () => await LoadData());
        }
        public Command GetDataCommand { get; }

        [ObservableProperty]
        ObservableCollection<WaitingOrderLine> selectedOrderLines;
        [ObservableProperty]
        Customer current;

        [ObservableProperty]
        ShipInfo shipInfo;

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
                    Code = SelectedOrderLines.First().CurrentCode,
                    Name = SelectedOrderLines.First().CurrentName
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
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineFormView)}", new Dictionary<string, object>
            {
                ["SelectedOrderLines"] = SelectedOrderLines,
                ["Current"] = Current,
                ["Warehouse"] = Warehouse,
                ["ShipInfo"] = ShipInfo
            });
        }
    }
}
