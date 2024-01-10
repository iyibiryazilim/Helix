using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels;

public partial class SupplierFastOperationBottomSheetViewModel : BaseViewModel
{
	[ObservableProperty]
	Current current;

	[RelayCommand]
	async Task GoToDispatchByPurchaseOrderFicheViewAsync() // Fişe Bağlı Satış İrsaliye İşlemi
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderFicheView)}", new Dictionary<string, object>
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
	async Task GoToDispatchByPurchaseOrderLineListViewAsync() // Satıra Bağlı Satış İrsaliye İşlemi
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineLineListView)}", new Dictionary<string, object>
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

	
}
