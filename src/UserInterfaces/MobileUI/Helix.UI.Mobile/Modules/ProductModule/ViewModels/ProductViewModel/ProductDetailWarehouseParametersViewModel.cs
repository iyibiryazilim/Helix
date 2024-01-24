using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel
{
	[QueryProperty(name: nameof(Product), queryId: nameof(Product))]

	public partial class ProductDetailWarehouseParametersViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		IWarehouseParameterService _wareHouseparameterService;


		[ObservableProperty]
		Product product;

		public ObservableCollection<WarehouseParameter> Items { get; } = new();
		public Command GetItemsCommand { get; }

		public Command PerformSearchCommand { get; }

		public ProductDetailWarehouseParametersViewModel(IHttpClientService httpClientService, IWarehouseParameterService warehouseParameterService)
		{
			Title = "Ambar Parametreleri";
			_httpClientService = httpClientService;
			_wareHouseparameterService = warehouseParameterService;

			GetItemsCommand = new Command(async () => await LoadData());
			PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

		}

		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 10;
		[ObservableProperty]
		bool includeWaiting = true;
		[ObservableProperty]
		WarehouseParameterOrderBy orderBy = WarehouseParameterOrderBy.warehousenumberasc;

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
		async Task ReloadAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;
				CurrentPage = 0;
				var httpClient = _httpClientService.GetOrCreateHttpClient();
				var result = await _wareHouseparameterService.GetWarehouseParameterByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

				if (result.Data.Any())
				{
					Items.Clear();
					foreach (var item in result.Data)
					{
						await Task.Delay(50);
						Items.Add(item);
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
		async Task LoadMoreAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				CurrentPage++;
				var result = await _wareHouseparameterService.GetWarehouseParameterByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					foreach (var item in result.Data)
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
				await Shell.Current.DisplayAlert("Load More Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}
		async Task PerformSearchAsync(string text)
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
				await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		public async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Numaraya Göre Artan", "Numaraya Göre Azalan");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Ad A-Z":
							OrderBy = WarehouseParameterOrderBy.warehousenameasc;
							await ReloadAsync();
							break;
						case "Ad Z-A":
							OrderBy = WarehouseParameterOrderBy.warehousenamedesc;
							await ReloadAsync();
							break;
						case "Numaraya Göre Artan":
							OrderBy = WarehouseParameterOrderBy.warehousenumberasc;
							await ReloadAsync();
							break;
						case "Numaraya Göre Azalan":
							OrderBy = WarehouseParameterOrderBy.warehousenumberdesc;
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
				await Shell.Current.DisplayAlert("Sort Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}


	}
}
