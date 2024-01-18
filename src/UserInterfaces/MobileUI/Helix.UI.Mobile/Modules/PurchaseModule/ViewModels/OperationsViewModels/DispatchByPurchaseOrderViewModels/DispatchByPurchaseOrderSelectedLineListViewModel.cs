using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(SelectedWaitingOrderLineGroupList), nameof(SelectedWaitingOrderLineGroupList))]
	public partial class DispatchByPurchaseOrderSelectedLineListViewModel : BaseViewModel
	{ 
		public DispatchByPurchaseOrderSelectedLineListViewModel()
		{
			Title = "Satınalma Ürünleri Düzenleme";
			GetOrderLinesCommand = new Command(async () => await LoadData());
 
		}
		[ObservableProperty]
		ObservableCollection<WaitingOrderLineGroup> selectedWaitingOrderLineGroupList;
		public ObservableCollection<WaitingOrderLineGroup> Result { get; } = new();
		public ObservableCollection<WaitingOrderLine> ChangedLineList { get; } = new();
		public Command GetOrderLinesCommand { get; }
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
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
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

				foreach (var item in SelectedWaitingOrderLineGroupList)
				{
					double lineQuantitySum = item.WaitingOrderLines.Sum(line => -(double)line.WaitingQuantity);
					lineQuantitySum = Math.Max(lineQuantitySum, 0);
					item.IsSelected = false;
					item.LineQuantity = lineQuantitySum;

					foreach (var line in item.WaitingOrderLines)
					{
						line.IsSelected = false;
					}

					Result.Add(item);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		public async Task DeleteQuantityAsync(WaitingOrderLine line)
		{
			var quantityChange = -1;
			var group = SelectedWaitingOrderLineGroupList.FirstOrDefault(x => x.Code == line.ProductCode);

			if (group != null && group.LineQuantity - quantityChange >= 0 && line.FifoQuantity + quantityChange >= 0 && line.FifoQuantity + quantityChange <= group.StockQuantity)
			{
				group.LineQuantity -= quantityChange;
				line.FifoQuantity += quantityChange;
			}
		}
		[RelayCommand]
		public async Task AddQuantityAsync(WaitingOrderLine line)
		{
			var quantityChange = 1;
			var group = SelectedWaitingOrderLineGroupList.FirstOrDefault(x => x.Code == line.ProductCode);

			if (group != null && group.LineQuantity - quantityChange >= 0 && line.FifoQuantity + quantityChange >= 0)
			{
				group.LineQuantity -= quantityChange;
				line.FifoQuantity += quantityChange;
			}
		}
		[RelayCommand]
		async Task GoToSummaryAsync()
		{
			try
			{
				foreach (var item in SelectedWaitingOrderLineGroupList.SelectMany(item => item.WaitingOrderLines.Where(line => line.FifoQuantity > 0)))
				{
					ChangedLineList.Add(item);
				}
				await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderSummaryView)}", new Dictionary<string, object>
				{
					[nameof(WaitingOrderLine)] = ChangedLineList
				});
			}
			catch (Exception ex)
			{

				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
			 
		}
	}
}
