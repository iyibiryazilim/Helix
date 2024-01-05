using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
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
	public partial class DispatchByPurchaseOrderFicheViewModel : BaseViewModel
    {

		IHttpClientService _httpClientService;
		IPurchaseOrderService _purchaseOrderService;

		[ObservableProperty]
		Supplier current;

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

		//Commands
		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }

		public DispatchByPurchaseOrderFicheViewModel(IHttpClientService httpClientService,IPurchaseOrderService purchaseOrderService)
        {
			Title = "Fiş Seçimi";
			_purchaseOrderService = purchaseOrderService;
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

		async Task GetPurchaseOrderAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _purchaseOrderService.GetObjectsByCurrentCode(httpClient, SearchText, OrderBy,Current.Code, CurrentPage, PageSize);
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<WaitingOrder>(item);
					Items.Add(obj);
					Result.Add(obj);
				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
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
						foreach(var item in Items.ToList().Where(x=>x.Code.Contains(SearchText)))
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
		private void ToggleSelection(WaitingOrder item)
		{
			item.IsSelected = !item.IsSelected;
			 
			if (item.IsSelected)
			{
				Items.Where(x=>x.Code == item.Code).First().IsSelected = item.IsSelected;
 			}
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
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineListView)}", new Dictionary<string, object>
				{
 				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}

		}
	}
}
