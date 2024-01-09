using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(WaitingOrderLine), nameof(WaitingOrderLine))]

	public partial class DispatchByPurchaseOrderSummaryViewModel : BaseViewModel
    {
		[ObservableProperty]
		ObservableCollection<WaitingOrderLine> waitingOrderLine;
		[ObservableProperty]
		Current current;      
        public Command GetDataCommand { get; }

		public DispatchByPurchaseOrderSummaryViewModel()
		{
			Title = "Özet";
			GetDataCommand = new Command(async () => await LoadData());
		}

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
				Current = new Supplier()
				{
					Code = WaitingOrderLine.First().CurrentCode,
					Name = WaitingOrderLine.First().CurrentName
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
	}
}
