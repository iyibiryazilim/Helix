using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels
{
	[QueryProperty(nameof(ChangedLineList), nameof(ChangedLineList))]
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))] 
	public partial class ReturnBySalesDispatchTransactionLineSummaryViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<DispatchTransactionLine> changedLineList;
		[ObservableProperty]
		Customer current;
		[ObservableProperty]
		Warehouse warehouse;
		public ReturnBySalesDispatchTransactionLineSummaryViewModel()
        {
            Title = "Özet";
            GetDataCommand = new Command(async () => await LoadData());
        }

        public Command GetDataCommand { get; }
 
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
                    Code = ChangedLineList.First().CurrentCode,
                    Name = ChangedLineList.First().CurrentName
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
            await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionLineFormView)}", new Dictionary<string, object>
            {
				["ChangedLines"] = ChangedLineList,
				[nameof(Current)] = Current,
				[nameof(Warehouse)] = Warehouse
			});
        }
    }
}
