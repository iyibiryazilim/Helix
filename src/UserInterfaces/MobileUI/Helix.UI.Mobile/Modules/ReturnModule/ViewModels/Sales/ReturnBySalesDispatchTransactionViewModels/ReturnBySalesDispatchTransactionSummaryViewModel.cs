using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels
{
	[QueryProperty(nameof(ChangedLineList), nameof(ChangedLineList))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(Current), nameof(Current))]

	public partial class ReturnBySalesDispatchTransactionSummaryViewModel: BaseViewModel
	{
		[ObservableProperty]
		Customer current;
		[ObservableProperty]
		Warehouse warehouse;
		[ObservableProperty]
        ObservableCollection<DispatchTransactionLine> changedLineList;

        public ReturnBySalesDispatchTransactionSummaryViewModel()
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
            await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionFormView)}", new Dictionary<string, object>
            {
                [nameof(ChangedLineList)] = ChangedLineList,
				[nameof(Current)] = Current,
				[nameof(Warehouse)] = Warehouse


			});
        }
    }
}
