using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels
{
    public partial class ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel : BaseViewModel
    {
        [ObservableProperty]
        DispatchTransactionLineGroup lineGroup;

        public ObservableCollection<DispatchTransactionLine> Result { get; } = new();

        public ReturnBySalesDispatchTransactionLineChangeBottomSheetViewModel()
        {
            LoadDataCommand = new Command(async () => await LoadData());

        }
        public Command LoadDataCommand { get; }

        [RelayCommand]
        public async Task DeleteQuantityAsync(DispatchTransactionLine line)
        {
            var quantityChange = 1;

            if (LineGroup != null && LineGroup.LineQuantity >= 0)
            {
                if (line.TempQuantity != 0)
                {
                    LineGroup.LineQuantity -= quantityChange;

                    line.TempQuantity -= quantityChange;
                }

            }
            else if (LineGroup.LineQuantity - quantityChange < 0)
            {
                LineGroup.LineQuantity = 0;

            }
        }

        [RelayCommand]
        public async Task AddQuantityAsync(DispatchTransactionLine line)
        {
            var quantityChange = 1;

            if (LineGroup != null && LineGroup.LineQuantity + quantityChange <= LineGroup.StockQuantity && line.TempQuantity + quantityChange <= line.Quantity)
            {
                LineGroup.LineQuantity += quantityChange;
                line.TempQuantity += quantityChange;
            }

        }
        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(GetLinesAsync);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task GetLinesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                foreach (var item in LineGroup.Lines)
                {
                    Result.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
