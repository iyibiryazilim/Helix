using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
[QueryProperty(name: nameof(Results), queryId: nameof(Results))]
public partial class WarehouseCountingSummaryViewModel : BaseViewModel
{

	[ObservableProperty]
	Warehouse selectedWarehouse;

	[ObservableProperty]
	public ObservableCollection<WarehouseTotal> results;

	public WarehouseCountingSummaryViewModel()
	{
		Title = "Ambar Sayım Özeti";
	}

	[RelayCommand]
	async Task GoToSuccessPageViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
			{
				["SuccessMessage"] = "Ambar Sayım Fişi Başarıyla Gönderildi."
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
