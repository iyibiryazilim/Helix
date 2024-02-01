using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WarehouseTransferOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(WarehouseTotal), queryId: nameof(WarehouseTotal))]
[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class WarehouseTransferOperationSelectedItemsListViewModel : BaseViewModel
{

	[ObservableProperty]
	ObservableCollection<WarehouseTotal> warehouseTotal;  // SelectedItems

	[ObservableProperty]
	Warehouse warehouse;   // SelectedWarehouse

	public ObservableCollection<WarehouseTotal> Result { get; } = new();

	public Command<string> SearchCommand { get; }
	public Command GetSelectedItemsCommand { get; }

	public WarehouseTransferOperationSelectedItemsListViewModel()
	{
		Title = "Seçilen Malzemeler";

		SearchCommand = new Command<string>(async (text) => await PerformSearchAsync(text));
		GetSelectedItemsCommand = new Command(async () => await LoadData());
	}

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTotalOrderBy warehouseTotalOrderBy = WarehouseTotalOrderBy.codeasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;

	public async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetSelectedItemsAsync);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	public async Task GetSelectedItemsAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			if (Result.Count > 0)
				Result.Clear();

			foreach (var item in WarehouseTotal)
			{
				Result.Add(item);
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}


	[RelayCommand]
	async Task RemoveItemAsync(WarehouseTotal item)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.ProductName} adlı malzeme çıkartılacaktır. Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
			if (answer)
			{
				item.IsSelected = false;
				WarehouseTotal.Remove(item);
				Result.Remove(item);
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Malzeme Silme Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}


	[RelayCommand]
	async Task IncrementQuantityAsync(WarehouseTotal item)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			item.QuantityCounter++;
			//item.OnHand++;
			item.TempOnhand++;
			
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Miktar Artırma Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task DecrementQuantityAsync(WarehouseTotal item)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			

			if (item.QuantityCounter > 1)
			{
				item.QuantityCounter--;
				item.TempOnhand--;
				
			}
				
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Miktar Azaltma Hatası", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	public async Task PerformSearchAsync(string text)
	{
		if (IsBusy)
			return;
		try
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Length >= 3)
				{
					SearchText = text.ToLower();
					Result.Clear();
					foreach (var item in WarehouseTotal.ToList().Where(x => x.ProductCode.ToLower().Contains(SearchText) || x.ProductName.ToLower().Contains(SearchText)))
					{
						Result.Add(item);
					}
				}
			}
		}
		catch (Exception ex)
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
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderBy(x => x.ProductName).ToList())
						{
							Result.Add(item);
						}
						break;

					case "Ad Z-A":
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderByDescending(x => x.ProductName).ToList())
						{
							Result.Add(item);
						}
						break;

					case "Kod A-Z":
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderBy(x => x.ProductCode).ToList())
						{
							Result.Add(item);
						}
						break;

					case "Kod Z-A":
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderByDescending(x => x.ProductCode).ToList())
						{
							Result.Add(item);
						}
						break;

					case "Miktara Göre Artan":
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderBy(x => x.OnHand).ToList())
						{
							Result.Add(item);
						}
						break;

					case "Miktara Göre Azalan":
						Result.Clear();
						foreach (var item in WarehouseTotal.OrderByDescending(x => x.OnHand).ToList())
						{
							Result.Add(item);
						}
						break;

					default:
						await GetSelectedItemsAsync();
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

	[RelayCommand]
	public async Task GoToBackAsync()
	{
		if (IsBusy)
			return;
		try
		{

			if (Result.Count == 0)

				await Shell.Current.GoToAsync("..");
			else
			{
				bool answer = await Shell.Current.DisplayAlert("Uyarı", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");
				if (answer)
				{
					await Shell.Current.GoToAsync("..");
					//Result.Clear();
					//WarehouseTotal.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");

		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	public async Task GoToWarehouseTransferOperationTransferredWarehouseListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			if(Result.Count < 1)
			{
				await Shell.Current.DisplayAlert("Hata", "Seçili bir malzemeniz olmadığından dolayı sonraki sayfaya geçiş yapamazsınız", "Tamam");
			}else
			{
				await Shell.Current.GoToAsync($"{nameof(WarehouseTransferOperationTransferredWarehouseListView)}", new Dictionary<string, object>
				{
					[nameof(Warehouse)] = Warehouse,  // Selected Warehouse
					[nameof(WarehouseTotal)] = Result // Selected Product
				});
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
