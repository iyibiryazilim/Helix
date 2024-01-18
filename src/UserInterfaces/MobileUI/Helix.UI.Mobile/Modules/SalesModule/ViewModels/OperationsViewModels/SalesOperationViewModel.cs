using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels
{
	public partial class SalesOperationViewModel : BaseViewModel
	{
        public SalesOperationViewModel()
        {
            Title = "Sevkiyat İşlemleri";
        }
        [RelayCommand]
        async Task GoToDispatchBySalesOrderCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderCustomerView)}");
        }

        //Ürün Toplama
        [RelayCommand]
        async Task GoToProcurementByProductView()
        {
            await Shell.Current.GoToAsync($"{nameof(ProcurementByProductView)}");
        }

        [RelayCommand]
        async Task GoToDispatchBySalesOrderLineCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineCustomerView)}");
        }

        [RelayCommand]
        async Task GoToSalesDispatchListViewAsync()
        {
            if (IsBusy)
				return;
            try
            {
                IsBusy = true;

			    await Shell.Current.GoToAsync($"{nameof(SalesDispatchListView)}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
				IsBusy = false;
			}
		}

        [RelayCommand]
        async Task GoToSalesDispatchWarehouseListViewAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                await Shell.Current.GoToAsync($"{nameof(SalesDispatchWarehouseListView)}");
            }
            catch(Exception ex)
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
