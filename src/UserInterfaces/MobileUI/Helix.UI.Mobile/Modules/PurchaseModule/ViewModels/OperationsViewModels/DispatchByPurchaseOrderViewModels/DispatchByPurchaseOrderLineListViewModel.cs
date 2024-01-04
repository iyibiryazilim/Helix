using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(WaitingOrder), nameof(WaitingOrder))]

	public partial class DispatchByPurchaseOrderLineListViewModel : BaseViewModel
    {
		IPurchaseOrderLineService _purchaseOrderLineService;
		IHttpClientService _httpClientService;

		public ObservableCollection<WaitingOrderLine> Items { get; } = new();

		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }

		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		PurchaseOrderLineOrderBy orderBy = PurchaseOrderLineOrderBy.dateasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;
		[ObservableProperty]
		WaitingOrder waitingOrder;

		public DispatchByPurchaseOrderLineListViewModel(IPurchaseOrderLineService purchaseOrderLineService, IHttpClientService httpClientService)
		{
			Title = "Satır Seçimi";

			_purchaseOrderLineService = purchaseOrderLineService;
			_httpClientService = httpClientService;

			GetDataCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));


		}

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
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
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
		async Task LoadMoreAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				CurrentPage++;
				var result = await _purchaseOrderLineService.GetWaitingOrderByCode(httpClient, SearchText, OrderBy, WaitingOrder.Code, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					foreach (var item in result.Data)
					{
						await Task.Delay(50);
						var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
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
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");

			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
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
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				CurrentPage = 0;
				var result = await _purchaseOrderLineService.GetWaitingOrderByCode(httpClient, SearchText, OrderBy, WaitingOrder.Code, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					Items.Clear();
					foreach (var item in result.Data)
					{
						await Task.Delay(50);
						var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
						Items.Add(obj);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
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
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Malzeme Kodu A-Z", "Malzeme Kodu Z-A", "Malzeme Ad A-Z", "Malzeme Ad Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Malzeme Kodu A-Z":
							OrderBy = PurchaseOrderLineOrderBy.productcodeasc;
							await ReloadAsync();
							break;
						case "Malzeme Kodu Z-A":
							OrderBy = PurchaseOrderLineOrderBy.productcodedesc;
							await ReloadAsync();
							break;
						case "Malzeme Ad A-Z":
							OrderBy = PurchaseOrderLineOrderBy.productnameasc;
							await ReloadAsync();
							break;
						case "Malzeme Ad Z-A":
							OrderBy = PurchaseOrderLineOrderBy.productnamedesc;
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
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}
	}
}
