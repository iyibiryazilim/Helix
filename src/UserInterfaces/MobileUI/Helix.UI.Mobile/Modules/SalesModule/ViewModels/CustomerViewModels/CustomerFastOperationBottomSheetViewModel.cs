using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels;

	public partial class CustomerFastOperationBottomSheetViewModel : BaseViewModel
{
    [ObservableProperty]
    Current current;
    public CustomerFastOperationBottomSheetViewModel()
    {
        
    }

    [RelayCommand]
    async Task GoToDispatchBySalesOrderFicheViewAsync()  // Fişe Bağlı Satış İrsaliye İşlemi
    {
        if(IsBusy)
            return;

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderShipInfoListView)}", new Dictionary<string, object>
            {
                [nameof(Current)] = Current
            });
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

	[RelayCommand]
	async Task GoToDispatchBySalesOrderLineLineListViewAsync()  // Satıra Bağlı Satış İrsaliye İşlemi
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineShipInfoListView)}", new Dictionary<string, object>
			{
				[nameof(Current)] = Current
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		finally
		{
			IsBusy = false;
		}
	}
}
