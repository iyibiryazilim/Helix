using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel
{
	public partial class WarehouseDetailBottomSheetViewModel : BaseViewModel
    {
		[ObservableProperty]
		Warehouse warehouse;
        public WarehouseDetailBottomSheetViewModel()
        {
            
        }

        [RelayCommand]
		async Task GoToWarehouseProductListViewAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				await Shell.Current.GoToAsync($"{nameof(WarehouseDetailProductListView)}", new Dictionary<string, object>
				{
					["Warehouse"] = Warehouse
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task GoToWarehouseInputTransactionListViewAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				await Shell.Current.GoToAsync($"{nameof(WarehouseDetailInputTransactionView)}", new Dictionary<string, object>
				{
					["Warehouse"] = Warehouse
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task GoToWarehouseOutputTransactionListViewAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				await Shell.Current.GoToAsync($"{nameof(WarehouseDetailOutputTransactionView)}", new Dictionary<string, object>
				{
					["Warehouse"] = Warehouse
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
