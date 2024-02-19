using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.ProductTransactionLineDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]
public partial class ProductDetailPurchaseDispatchListViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	IProductTransactionLineService _productTransactionLineService;

	[ObservableProperty]
	Product product;
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	ProductTransactionLineOrderBy orderBy = ProductTransactionLineOrderBy.datedesc;

	public ObservableCollection<ProductTransactionLine> ProductTransactionPurchaseDispatchListItems { get; } = new();
	public Command GetProductTransactionPurchaseDispatchListItemsCommand { get; }
	public Command SearchCommand { get; }

	public ProductDetailPurchaseDispatchListViewModel(IHttpClientService httpClient, IProductTransactionLineService productTransactionLineService)
	{
		Title = "Satınalma İrsaliyesi";
		_httpClient = httpClient;
		_productTransactionLineService = productTransactionLineService;

		GetProductTransactionPurchaseDispatchListItemsCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
	}

	public async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(1000);
			await MainThread.InvokeOnMainThreadAsync(ReloadAsync);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
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
			var httpClient = _httpClient.GetOrCreateHttpClient();

			CurrentPage++;
			var result = await _productTransactionLineService.GetTransactionLinesByTransactionType(httpClient, Product.Code, "1", SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					ProductTransactionPurchaseDispatchListItems.Add(item);
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
			await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");

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
			var httpClient = _httpClient.GetOrCreateHttpClient();
			CurrentPage = 0;

			var result = await _productTransactionLineService.GetTransactionLinesByTransactionType(httpClient, Product.Code, "1", SearchText, OrderBy, CurrentPage, PageSize);

			ProductTransactionPurchaseDispatchListItems.Clear();
			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					await Task.Delay(200);
					ProductTransactionPurchaseDispatchListItems.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarihe Göre A-Z", "Tarihe Göre Z-A", "Miktara Göre A-Z", "Miktara Göre Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Tarihe Göre A-Z":
						OrderBy = ProductTransactionLineOrderBy.dateasc;
						await ReloadAsync();
						break;
					case "Tarihe Göre Z-A":
						OrderBy = ProductTransactionLineOrderBy.datedesc;
						await ReloadAsync();
						break;
					case "Miktara Göre A-Z":
						OrderBy = ProductTransactionLineOrderBy.quantityasc;
						await ReloadAsync();
						break;
					case "Miktara Göre Z-A":
						OrderBy = ProductTransactionLineOrderBy.quantitydesc;
						await ReloadAsync();
						break;
					default:
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
	public async Task GoToBackAsync()
	{
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync("..");
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
