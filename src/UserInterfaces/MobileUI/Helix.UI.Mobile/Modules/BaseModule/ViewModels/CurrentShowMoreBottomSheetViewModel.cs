using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
 using Helix.UI.Mobile.Modules.BaseModule.Views.Current;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.MVVMHelper;
 
namespace Helix.UI.Mobile.Modules.BaseModule.ViewModels
{
	public partial class CurrentShowMoreBottomSheetViewModel : BaseViewModel
    {
		[ObservableProperty]
		Current current;
        public CurrentShowMoreBottomSheetViewModel()
        {
        }

        [RelayCommand]
        public async Task GoToInputListAsync()
        {
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentInputListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToOutputListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentOutputListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToPurchaseDispatchListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseDispatchListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesDispatchListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesDispatchListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		public async Task GoToPurchaseOrderListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseOrderListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesOrderListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesOrderListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		public async Task GoToPurchaseReturnListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseReturnListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesReturnListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesReturnListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = Current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
		}
	}
}
