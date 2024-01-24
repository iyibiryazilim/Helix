using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]

	public partial class DispatchByPurchaseOrderFicheViewModel : BaseViewModel
	{

		IHttpClientService _httpClientService;
		IPurchaseOrderService _purchaseOrderService;

		[ObservableProperty]
		Supplier current;

		[ObservableProperty]
		Warehouse warehouse;


		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		PurchaseOrderOrderBy orderBy = PurchaseOrderOrderBy.dateasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 3000;

		//Lists
		public ObservableCollection<WaitingOrder> Items { get; } = new();
		public ObservableCollection<WaitingOrder> Result { get; } = new();
		public ObservableCollection<WaitingOrder> SelectedOrders { get; } = new();

		//Commands
		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }
		public Command SelectAllCommand { get; }


		public DispatchByPurchaseOrderFicheViewModel(IHttpClientService httpClientService, IPurchaseOrderService purchaseOrderService)
		{
			Title = "Fiş Seçimi";
			_purchaseOrderService = purchaseOrderService;
			_httpClientService = httpClientService;

			GetDataCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
			SelectAllCommand = new Command<bool>(async (isSelected) => await SelectAllAsync(isSelected));

		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetPurchaseOrderAsync);

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

		[RelayCommand]
		async Task GetPurchaseOrderAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _purchaseOrderService.GetObjectsByCurrentIdAndWarehouseNumber(httpClient, SearchText, OrderBy, Current.ReferenceId, Warehouse.Number, CurrentPage, PageSize);
				if (result.IsSuccess)
				{
					if (Items.Any())
					{
						Items.Clear();
						Result.Clear();
					}
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<WaitingOrder>(item);
						Items.Add(obj);
						Result.Add(obj);
					}
				}
				else
				{
					await Shell.Current.DisplayAlert("Error: ", $"{result.Message}", "Tamam");

				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error ", $"{ex.Message}", "Tamam");
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
						Result.Clear();
						foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText)))
						{
							Result.Add(item);
						}
					}
				}
				else
				{
					SearchText = string.Empty;
					Result.Clear();
					foreach (var item in Items)
					{
						Result.Add(item);
					}
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
		public async Task SelectAsync(WaitingOrder item)
		{
			await Task.Run(() =>
			{
				WaitingOrder selectedItem = Result.FirstOrDefault(x => x.ReferenceId == item.ReferenceId);
				if (selectedItem != null)
				{
					if (selectedItem.IsSelected)
					{
						selectedItem.IsSelected = false;
						SelectedOrders.Remove(selectedItem);

					}
					else
					{
						selectedItem.IsSelected = true;

						SelectedOrders.Add(selectedItem);
					}
				}

			});
		}

		[RelayCommand]
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarih A-Z", "Tarih Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Tarih A-Z":
							OrderBy = PurchaseOrderOrderBy.datedesc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.Date))
							{
								Result.Add(item);
							}
							break;
						case "Tarih Z-A":
							OrderBy = PurchaseOrderOrderBy.dateasc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.Date))
							{
								Result.Add(item);
							}
							break;
						default:
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.Date))
							{
								Result.Add(item);
							}
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

		[RelayCommand]
		async Task GoToLinesAsync()
		{
			if (IsBusy)
				return;

			try
			{
				if (SelectedOrders.Count > 0)
				{

					await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineListView)}", new Dictionary<string, object>
					{
						[nameof(SelectedOrders)] = SelectedOrders,
						["Warehouse"] = Warehouse

					});
				}
				else
				{
					await Shell.Current.DisplayAlert("Uyarı", "Sipariş Seçiniz", "Tamam");
				}

			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}

		}

		public async Task SelectAllAsync(bool isSelected)
		{
			if (isSelected)
			{
				Result.Clear();
				foreach (var item in Items)
				{
					Result.Add(item);
					item.IsSelected = true;
				}
			}
			else
			{
				Result.Clear();
				foreach (var item in Items)
				{
					Result.Add(item);
					item.IsSelected = false;
				}
			}
		}

	}
}
