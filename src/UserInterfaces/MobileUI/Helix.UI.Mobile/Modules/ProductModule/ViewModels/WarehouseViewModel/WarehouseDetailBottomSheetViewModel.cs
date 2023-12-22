using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
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
				//await Shell.Current.GoToAsync($"{nameof(WarehouseProductListView)}", new Dictionary<string, object>
				//{
				//	["Warehouse"] = Warehouse
				//});
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
				//await Shell.Current.GoToAsync($"{nameof(WarehouseInputTransactionListView)}", new Dictionary<string, object>
				//{
				//	["Warehouse"] = Warehouse
				//});
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
				//await Shell.Current.GoToAsync($"{nameof(WarehouseOutputTransactionListView)}", new Dictionary<string, object>
				//{
				//	["Warehouse"] = Warehouse
				//});
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
