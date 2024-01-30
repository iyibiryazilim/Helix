using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnByPurchaseDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
	[QueryProperty(nameof(ChangedLineList), nameof(ChangedLineList))]
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(ShipInfo), nameof(ShipInfo))]
	public partial class ReturnByPurchaseDispatchTransactionSummaryViewModel : BaseViewModel
	{
		[ObservableProperty]
		ObservableCollection<DispatchTransactionLine> changedLineList;

		public ReturnByPurchaseDispatchTransactionSummaryViewModel()
		{
			Title = "Özet";
			GetDataCommand = new Command(async () => await LoadData());
		}

		public Command GetDataCommand { get; }
 
		[ObservableProperty]
		Supplier current;

		[ObservableProperty]
		Warehouse warehouse;
		[ObservableProperty]
		ShipInfo shipInfo;

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
		async Task GoToOrderForm()
		{
			await Shell.Current.GoToAsync($"{nameof(ReturnByPurchaseDispatchTransactionFormView)}", new Dictionary<string, object>
			{
				[nameof(ChangedLineList)] = ChangedLineList,
				[nameof(Current)] = Current,
				[nameof(Warehouse)] = Warehouse,
				[nameof(ShipInfo)] = ShipInfo

			});
		}
	}
}
