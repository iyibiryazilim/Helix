using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(WarehouseTotal), queryId: nameof(WarehouseTotal))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]

public partial class WarehouseTransferOperationSummaryViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<WarehouseTotal> warehouseTotal;

	[ObservableProperty]
	Warehouse warehouse;

	[ObservableProperty]
	Warehouse selectedWarehouse;

	public WarehouseTransferOperationSummaryViewModel()
	{
		Title = "Transfer Özeti";
	}

	[RelayCommand]
	async Task GoToWarehouseTransferOperationViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(WarehouseTransferOperationFormView)}", new Dictionary<string, object>
			{
				[nameof(Warehouse)] = Warehouse,
				[nameof(SelectedWarehouse)] = SelectedWarehouse
			});
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}
	}
}
