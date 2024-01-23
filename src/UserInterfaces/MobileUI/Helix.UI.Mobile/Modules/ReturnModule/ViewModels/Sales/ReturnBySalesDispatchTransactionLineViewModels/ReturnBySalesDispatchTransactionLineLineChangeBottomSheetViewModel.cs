using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels
{
    public partial class ReturnBySalesDispatchTransactionLineLineChangeBottomSheetViewModel : BaseViewModel
    {
        [ObservableProperty]
        DispatchTransactionLineGroup lineGroup;
        public ObservableCollection<DispatchTransactionLine> Result { get; } = new();

        public ReturnBySalesDispatchTransactionLineLineChangeBottomSheetViewModel()
        {
            LoadDataCommand = new Command(async () => await LoadData());

        }
        public Command LoadDataCommand { get; }

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
                await Shell.Current.DisplayAlert("Return Sales Dispatch Transaction Error: ", $"{ex.Message}", "Tamam");
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
