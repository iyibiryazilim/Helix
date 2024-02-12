using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;

public partial class WarehouseCountingSelectProductsViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IProductService _productService;
	IServiceProvider _serviceProvider;

	public Command GetItemsCommand { get; }
	public Command<string> SearchCommand { get; }
	public WarehouseCountingSelectProductsViewModel(IHttpClientService httpClientService, IProductService productService, IServiceProvider serviceProvider)
	{
		Title = "Ürün Seçimi";
		_httpClientService = httpClientService;
		_productService = productService;
		_serviceProvider = serviceProvider;

		GetItemsCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
	}

	#region Lists
	public ObservableCollection<Product> Items { get; } = new();
	public ObservableCollection<Product> SelectedItems { get; } = new();
	#endregion

	#region Properties
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	ProductOrderBy orderBy = ProductOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;


	ObservableCollection<Product> SelectedProducts { get; } = new();

	#endregion

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(ReloadAsync);
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

	[RelayCommand]
	async Task GetProductsListAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();

				foreach (var item in result.Data)
				{
					Items.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
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
					SearchText = text;
					await ReloadAsync();
				}
			}
			else
			{
				SearchText = string.Empty;
				await ReloadAsync();
			}
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

	[RelayCommand]
	public async Task LoadMoreAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage++;
			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (Product item in result.Data)
				{
					await Task.Delay(100);
					Items.Add(item);
				}
			}
			else
			{
				CurrentPage--;
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");

		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
	[RelayCommand]
	public async Task ReloadAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage = 0;
			Items.Clear();

			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (Product item in result.Data)
				{
					await Task.Delay(100);
					Items.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	public async Task SortAsync()
	{
		if (IsBusy) return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Kod A-Z":
						OrderBy = ProductOrderBy.codeasc;
						await ReloadAsync();
						break;
					case "Kod Z-A":
						OrderBy = ProductOrderBy.codedesc;
						await ReloadAsync();
						break;
					case "Ad A-Z":
						OrderBy = ProductOrderBy.nameasc;
						await ReloadAsync();
						break;
					case "Ad Z-A":
						OrderBy = ProductOrderBy.namedesc;
						await ReloadAsync();
						break;
					default:
                        OrderBy = ProductOrderBy.nameasc;
                        await ReloadAsync();
						break;

				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	public async Task ToggleSelectionAsync(Product item)
	{
		try
		{
			item.IsSelected = !item.IsSelected;
			if (item.IsSelected)
			{
				SelectedProducts.Add(item);
			}
			else
			{
				SelectedProducts.Remove(item);
			}
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

	[RelayCommand]
	public async Task SelectAllAsync(bool isSelected)
	{
		try
		{
			if (isSelected)
			{
				foreach (var item in Items)
				{
					item.IsSelected = true;
					SelectedProducts.Add(item);
				}
			}
			else
			{
				foreach (var item in Items)
				{
					item.IsSelected = false;
					SelectedProducts.Remove(item);
				}
			}
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
	public async Task GoToNextAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			var warehouseCountingListViewModel  = _serviceProvider.GetService<WarehouseCountingListViewModel>();

			foreach(var item in SelectedProducts)
			{
				if(warehouseCountingListViewModel.Items.ToList().Exists(x => x.ProductCode == item.Code))
				{
					//warehouseCountingListViewModel.Items.ToList().First(x => x.ProductCode == item.Code).OnHand += 1;
					warehouseCountingListViewModel.Items.ToList().First(x => x.ProductCode == item.Code).TempOnhand += 1;
					warehouseCountingListViewModel.Items.ToList().First(x => x.ProductCode == item.Code).QuantityCounter += 1;
				}
				if (warehouseCountingListViewModel.Results.ToList().Exists(x => x.ProductCode == item.Code))
				{
					//warehouseCountingListViewModel.Results.ToList().First(x => x.ProductCode == item.Code).OnHand += 1;
					warehouseCountingListViewModel.Results.ToList().First(x => x.ProductCode == item.Code).TempOnhand += 1;
					warehouseCountingListViewModel.Results.ToList().First(x => x.ProductCode == item.Code).QuantityCounter += 1;
				}

				var model = new WarehouseTotal
				{
					ProductReferenceId = item.ReferenceId,
					ProductCode = item.Code,
					ProductName = item.Name,
					SubUnitsetCode = item.SubUnitsetCode,
					OnHand = item.StockQuantity,
					TempOnhand = item.TempOnhand
					
				};
				item.IsSelected = false;
				if (!warehouseCountingListViewModel.Results.ToList().Exists(x => x.ProductCode == item.Code))
				{
					warehouseCountingListViewModel.Items.Add(model);
					warehouseCountingListViewModel.Results.Add(model);
				}
			}

			await Task.Delay(200);
			await Shell.Current.GoToAsync("..");

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
