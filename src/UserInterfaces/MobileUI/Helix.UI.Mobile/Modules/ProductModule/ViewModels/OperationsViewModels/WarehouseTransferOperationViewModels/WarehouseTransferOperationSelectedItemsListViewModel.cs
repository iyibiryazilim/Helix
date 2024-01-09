using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

	public ObservableCollection<WarehouseTotal> Result { get; } = new();

	public Command<string> SearchCommand { get; }
	public Command GetSelectedItemsCommand { get; }

	public WarehouseTransferOperationSelectedItemsListViewModel()
	{
		//Title = "Seçilen Ürünler";
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

	[RelayCommand]
	async Task SortAsync()
	{
		if (IsBusy)
			return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Kod A-Z", "Kod Z-A", "Miktara Göre Artan", "Miktara Göre Azalan");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Ad A-Z":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.nameasc;
						
						break;
					case "Ad Z-A":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.namedesc;
						
						break;
					case "Kod A-Z":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.codeasc;
						
						break;
					case "Kod Z-A":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.codedesc;
						
						break;
					case "Miktara Göre Artan":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.quantityasc;
						
						break;
					case "Miktara Göre Azalan":
						WarehouseTotalOrderBy = WarehouseTotalOrderBy.quantitydesc;
						
						break;
					default:
						
						break;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Sıralama Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
}
