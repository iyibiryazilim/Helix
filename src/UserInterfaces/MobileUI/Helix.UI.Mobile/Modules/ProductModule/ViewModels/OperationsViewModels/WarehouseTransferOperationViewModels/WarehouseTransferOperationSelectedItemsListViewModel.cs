using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(WarehouseTotal), queryId: nameof(WarehouseTotal))]
public partial class WarehouseTransferOperationSelectedItemsListViewModel : BaseViewModel
{

	[ObservableProperty]
	ObservableCollection<WarehouseTotal> warehouseTotal;

	ObservableCollection<WarehouseTotal> Result { get; } = new();

	public Command<string> SearchCommand { get; }

	public WarehouseTransferOperationSelectedItemsListViewModel()
	{
		SearchCommand = new Command<string>(async (text) => await PerformSearchAsync(text));
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTotalOrderBy warehouseTotalOrderBy = WarehouseTotalOrderBy.codeasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;


	public async Task PerformSearchAsync(string text)
	{
		if (IsBusy)
			return;
		try
		{
			if(!string.IsNullOrEmpty(text))
			{
				if(text.Length >= 3)
				{
					SearchText = text;
					Result.Clear();
					foreach (var item in WarehouseTotal.ToList().Where(x => x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
					{
						Result.Add(item);
					}
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
