using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))] 
	public partial class ReturnByPurchaseDispatchTransactionShipInfoListViewModel : BaseViewModel
    {
		IHttpClientService _httpClientService;
		private readonly IShipInfoService _shipInfoService;
		//Lists
		public ObservableCollection<ShipInfo> Items { get; } = new();
		public ObservableCollection<ShipInfo> Results { get; } = new();


		//Commands
		public Command GetShipInfosCommand { get; }
		public Command SearchCommand { get; }

		//Properties
		[ObservableProperty]
		string searchText = string.Empty;

		[ObservableProperty]
		ShipInfo selectedShipInfo;

		[ObservableProperty]
		Customer current;


		public ReturnByPurchaseDispatchTransactionShipInfoListViewModel(IHttpClientService httpClientService, IShipInfoService shipInfoService)
		{
			Title = "Sevk Adresleri";
			_httpClientService = httpClientService;
			_shipInfoService = shipInfoService;
			GetShipInfosCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetShipInfosAsync);

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
		async Task GetShipInfosAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();


				var result = await _shipInfoService.GetObjectsByCurrentId(httpClient, Current.ReferenceId);
				if (result.Data.Count() == 0)
				{
					await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderWarehouseListView)}", new Dictionary<string, object>
					{
						["ShipInfo"] = SelectedShipInfo,
						["Current"] = Current
					});
				}

				foreach (ShipInfo item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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
						Results.Clear();
						foreach (var item in Items.ToList().Where(x => x.Name.Contains(SearchText) || x.Code.ToString().Contains(SearchText)))
						{
							Results.Add(item);
						}
					}
				}
				else
				{
					SearchText = string.Empty;
					Results.Clear();
					foreach (var item in Items)
					{
						Results.Add(item);
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
		async Task ReloadAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _shipInfoService.GetObjectsByCurrentId(httpClient, Current.ReferenceId);
				foreach (ShipInfo item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Ad A-Z", "Ad Z-A", "Kod A-Z", "Kod Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					await Task.Delay(100);
					switch (response)
					{
						case "Ad A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Name).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Name).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Kod A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Code).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Kod Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Code).ToList())
							{
								Results.Add(item);
							}
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

		[RelayCommand]
		async Task GoToTransaction()
		{
			if (SelectedShipInfo == null)
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Ambar seçimi yapmanız gerekmektedir", "Tamam");
			}
			else
			{
				await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderWarehouseListView)}", new Dictionary<string, object>
				{
					["ShipInfo"] = SelectedShipInfo,
					["Current"] = Current
				});
			}

		}

		[RelayCommand]
		private void ToggleSelection(ShipInfo item)
		{
			item.IsSelected = !item.IsSelected;
			if (SelectedShipInfo != null)
			{
				SelectedShipInfo.IsSelected = false;
			}
			if (item.IsSelected)
			{
				SelectedShipInfo = item;
			}
		}
	}
}
