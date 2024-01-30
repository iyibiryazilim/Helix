using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels
{
	[QueryProperty(nameof(ChangedLines), nameof(ChangedLines))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class DispatchByPurchaseOrderLineSummaryViewModel : BaseViewModel
    {
		[ObservableProperty]
		ObservableCollection<WaitingOrderLine> changedLines;
		[ObservableProperty]
		Supplier current;
		[ObservableProperty]
		Warehouse warehouse;
 

		public Command GetDataCommand { get; }

        public DispatchByPurchaseOrderLineSummaryViewModel()
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
		async Task GoToFormAsync()
		{
			await Task.Delay(500);
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineFormView)}", new Dictionary<string, object>
			{
				[nameof(ChangedLines)] = ChangedLines,
				[nameof(Warehouse)] = Warehouse,
				[nameof(Current)] = Current
			});
		}
	}
}
