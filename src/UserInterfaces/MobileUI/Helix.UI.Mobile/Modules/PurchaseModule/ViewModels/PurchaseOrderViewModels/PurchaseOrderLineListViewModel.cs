using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PurchaseOrderViewModels
{
	public partial class PurchaseOrderLineListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		IPurchaseOrderLineService _purchaseOrderLineService;

		public PurchaseOrderLineListViewModel(IHttpClientService httpClientService, IPurchaseOrderLineService purchaseOrderLineService)
		{
			Title = "Satınalma Siparişleri";
			_httpClientService = httpClientService;
			_purchaseOrderLineService = purchaseOrderLineService;

			GetPurchaseOrderLineItemsCommand = new Command(async () => await LoadData());
			PerformSearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		}

		public ObservableCollection<WaitingOrderLine> Items { get; } = new();
		public Command GetPurchaseOrderLineItemsCommand { get; }
		public Command PerformSearchCommand { get; }

		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		PurchaseOrderLineOrderBy orderBy = PurchaseOrderLineOrderBy.datedesc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;

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

                var httpClient = _httpClientService.GetOrCreateHttpClient();
				CurrentPage = 0;
				var result = await _purchaseOrderLineService.GetWaitingOrders(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					Items.Clear();
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
						await Task.Delay(100);
						Items.Add(obj);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Reload Error: ", $"{ex.Message}", "Tamam");
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
				IsRefreshing = true;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				CurrentPage++;
				var result = await _purchaseOrderLineService.GetWaitingOrders(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
						await Task.Delay(100);
						Items.Add(obj);
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
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ürün Adı A-Z", "Ürün Adı Z-A", "Ürün Kodu A-Z", "Ürün Kodu Z-A", "Tarihe Göre Artan", "Tarihe Göre Azalan", "Müşteri Adı A-Z", "Müşteri Adı Z-A", "Müşteri Kodu A-Z", "Müşteri Kodu Z-A");

				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Ürün Adı A-Z":
						OrderBy = PurchaseOrderLineOrderBy.productnameasc;
						await ReloadAsync();
						break;
					case "Ürün Adı Z-A":
						OrderBy = PurchaseOrderLineOrderBy.productnamedesc;
						await ReloadAsync();
						break;
					case "Ürün Kodu A-Z":
						OrderBy = PurchaseOrderLineOrderBy.productcodeasc;
						await ReloadAsync();
						break;
					case "Ürün Kodu Z-A":
						OrderBy = PurchaseOrderLineOrderBy.productcodedesc;
						await ReloadAsync();
						break;
					case "Tarihe Göre Artan":
						OrderBy = PurchaseOrderLineOrderBy.dateasc;
						await ReloadAsync();
						break;
					case "Tarihe Göre Azalan":
						OrderBy = PurchaseOrderLineOrderBy.datedesc;
						await ReloadAsync();
						break;
					case "Müşteri Adı A-Z":
						OrderBy = PurchaseOrderLineOrderBy.currentnameasc;
						await ReloadAsync();
						break;
					case "Müşteri Adı Z-A":
						OrderBy = PurchaseOrderLineOrderBy.currentnamedesc;
						await ReloadAsync();
						break;
					case "Müşteri Kodu A-Z":
						OrderBy = PurchaseOrderLineOrderBy.currentcodeasc;
						await ReloadAsync();
						break;
					case "Müşteri Kodu Z-A":
						OrderBy = PurchaseOrderLineOrderBy.currentcodedesc;
						await ReloadAsync();
						break;
					default:
						await ReloadAsync();
						break;
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

	}
}
