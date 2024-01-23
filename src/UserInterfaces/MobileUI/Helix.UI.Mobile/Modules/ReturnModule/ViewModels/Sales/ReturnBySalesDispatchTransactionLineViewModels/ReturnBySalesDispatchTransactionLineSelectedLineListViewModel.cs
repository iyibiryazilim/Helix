using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels
{
    [QueryProperty(nameof(SelectedDispatchTransactionLineGroupList), nameof(SelectedDispatchTransactionLineGroupList))]

    public partial class ReturnBySalesDispatchTransactionLineSelectedLineListViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<DispatchTransactionLineGroup> selectedDispatchTransactionLineGroupList;
        public ObservableCollection<DispatchTransactionLineGroup> Result { get; } = new();
        public ObservableCollection<DispatchTransactionLine> ChangedLineList { get; } = new();

        public ReturnBySalesDispatchTransactionLineSelectedLineListViewModel()
        {
            Title = "Malzeme Düzenleme";
            GetSelectedLinesCommand = new Command(async () => await LoadData());

        }
        public Command GetSelectedLinesCommand { get; }
        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(GetSalesOrdersAsync);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Selected Products Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetSalesOrdersAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                IsRefreshing = false;
                Result.Clear();

                foreach (var item in SelectedDispatchTransactionLineGroupList)
                {

                    item.IsSelected = false;

                    foreach (var line in item.Lines)
                    {
                        line.IsSelected = false;
                    }

                    Result.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Selected Products Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task DeleteQuantityAsync(DispatchTransactionLine line)
        {
            var quantityChange = 1;
            var group = SelectedDispatchTransactionLineGroupList.FirstOrDefault(x => x.Code == line.ProductCode);

            if (group != null && group.LineQuantity >= 0)
            {
                if (line.TempQuantity != 0)
                {
                    group.LineQuantity -= quantityChange;
                    line.TempQuantity -= quantityChange;
                }

            }
            else if (group.LineQuantity - quantityChange < 0)
            {
                group.LineQuantity = 0;

            }
        }

        [RelayCommand]
        public async Task AddQuantityAsync(DispatchTransactionLine line)
        {
            var quantityChange = 1;
            var group = SelectedDispatchTransactionLineGroupList.FirstOrDefault(x => x.Code == line.ProductCode);

            if (group != null && group.LineQuantity <= group.StockQuantity)
            {
                group.LineQuantity += quantityChange;
                line.TempQuantity += quantityChange;
            }
            else if (group.LineQuantity - quantityChange < 0)
            {
                group.LineQuantity = 0;

            }
        }

        [RelayCommand]
        public async Task GoToSummaryAsync()
        {
            try
            {
                foreach (var item in SelectedDispatchTransactionLineGroupList.SelectMany(item => item.Lines.Where(line => line.TempQuantity > 0)))
                {
                    ChangedLineList.Add(item);
                }
                await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionLineSummaryView)}", new Dictionary<string, object>
                {
                    [nameof(ChangedLineList)] = ChangedLineList
                });
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Selected Products Error: ", $"{ex.Message}", "Tamam");
            }
        }
    }
}
