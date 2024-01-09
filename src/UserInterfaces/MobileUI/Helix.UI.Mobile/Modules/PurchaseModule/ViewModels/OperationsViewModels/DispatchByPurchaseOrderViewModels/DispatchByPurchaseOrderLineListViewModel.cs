using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
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
		public ObservableCollection<WaitingOrderLine> Result { get; } = new();
		public ObservableCollection<WaitingOrderLine> SelectedLines { get; } = new();

		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }
		public Command SelectAllCommand { get; }
 
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		PurchaseOrderLineOrderBy orderBy = PurchaseOrderLineOrderBy.dateasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;
		[ObservableProperty]
		List<WaitingOrder> waitingOrder;

		public DispatchByPurchaseOrderLineListViewModel(IPurchaseOrderLineService purchaseOrderLineService, IHttpClientService httpClientService)
		{
			Title = "Satır Seçimi";

			_purchaseOrderLineService = purchaseOrderLineService;
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
				await MainThread.InvokeOnMainThreadAsync(GetLinesAsync);

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
						Result.Clear();
						foreach (var item in Items.ToList().Where(x => x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
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
		private void ToggleSelection(WaitingOrderLine item)
		{
			item.IsSelected = !item.IsSelected;

			if (item.IsSelected)
			{
				Items.Where(x => x.ReferenceId == item.ReferenceId).First().IsSelected = item.IsSelected;
			}
		}

		[RelayCommand]
		public async Task GetLinesAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();
				if (Items.Any())
				{
					Items.Clear();
					Result.Clear();
				}
				foreach (var fiche in WaitingOrder)
				{
					var result = await _purchaseOrderLineService.GetWaitingOrderByCode(httpClient, SearchText, OrderBy, fiche.Code, CurrentPage, PageSize);
					foreach (var item in result.Data)
					{
						var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
						Items.Add(obj);
						Result.Add(obj);
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
			}
		}

		[RelayCommand]
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarih A-Z", "Tarih Z-A","Malzeme Adı A-Z","Malzeme Adı Z-A", "Malzeme Kodu A-Z", "Malzeme Kodu Z-A", "Miktar A-Z","Miktar Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Tarih A-Z":
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.DueDate))
							{
								Result.Add(item);
							}
							break;
						case "Tarih Z-A":
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.DueDate))
							{
								Result.Add(item);
							}
							break;
						case "Malzeme Adı A-Z":
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.ProductName))
							{
								Result.Add(item);
							}
							break;
						case "Malzeme Adı Z-A":
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.ProductName))
							{
								Result.Add(item);
							}
							break;
						case "Malzeme Kodu A-Z":
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.ProductCode))
							{
								Result.Add(item);
							}
							break;
						case "Malzeme Kodu Z-A":
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.ProductCode))
							{
								Result.Add(item);
							}
							break;
						case "Miktar A-Z":
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.WaitingQuantity))
							{
								Result.Add(item);
							}
							break;
						case "Miktar Z-A":
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.WaitingQuantity))
							{
								Result.Add(item);
							}
							break;
						default:
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.DueDate))
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
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		async Task GoToSummaryAsync()
		{
			if (IsBusy)
				return;

			try
			{
				if(Items.Where(x => x.IsSelected).ToList().Any())
				{
					foreach (var item in Items.Where(x => x.IsSelected))
					{
						SelectedLines.Add(item);
					}
					await Task.Delay(500);
					await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderSelectedLineListView)}", new Dictionary<string, object>
					{
						[nameof(WaitingOrderLine)] = SelectedLines
					});
				}
				else
				{
					await Shell.Current.DisplayAlert("Uyarı", "Satır Seçiniz", "Tamam");
				}

			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}

		}

		public async Task SelectAllAsync(bool isSelected)
		{
			await Task.Run(() =>
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
			});
		}
	}
}
