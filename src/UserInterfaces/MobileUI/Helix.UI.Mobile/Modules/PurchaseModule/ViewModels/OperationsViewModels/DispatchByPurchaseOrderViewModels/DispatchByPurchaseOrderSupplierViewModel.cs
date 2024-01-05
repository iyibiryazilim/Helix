using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
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
	public partial class DispatchByPurchaseOrderSupplierViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ISupplierService _supplierService;
		//Lists
		public ObservableCollection<Current> Items { get; } = new();
		//Commands
		public Command GetDataCommand { get; }
		public Command SearchCommand { get; }
		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		SupplierOrderBy orderBy = SupplierOrderBy.nameasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;

		[ObservableProperty]
		Current selectedCurrent;

		public DispatchByPurchaseOrderSupplierViewModel(IHttpClientService httpClientService, ISupplierService supplierService)
		{
			Title = "Tedarikçi Seçimi";
			_httpClientService = httpClientService;
			_supplierService = supplierService;
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
				var result = await _supplierService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					foreach (Supplier item in result.Data)
					{
						await Task.Delay(50);
						if(SelectedCurrent != null)
						{
							if (item.Code == SelectedCurrent.Code)
								item.IsSelected = true;
						}
						
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
				var result = await _supplierService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					Items.Clear();
					foreach (Supplier item in result.Data)
					{
						await Task.Delay(50);
						if (SelectedCurrent != null)
						{
							if (item.Code == SelectedCurrent.Code)
								item.IsSelected = true;
						}

						Items.Add(item);
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
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Kod A-Z":
							OrderBy = SupplierOrderBy.codeasc;
							await ReloadAsync();
							break;
						case "Kod Z-A":
							OrderBy = SupplierOrderBy.codedesc;
							await ReloadAsync();
							break;
						case "Ad A-Z":
							OrderBy = SupplierOrderBy.nameasc;
							await ReloadAsync();
							break;
						case "Ad Z-A":
							OrderBy = SupplierOrderBy.namedesc;
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

		[RelayCommand]
		async Task GoToFicheListAsync()
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderFicheView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = SelectedCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		async Task ToggleSelectionAsync(Current current)
		{
			current.IsSelected = !current.IsSelected;
			if (SelectedCurrent != null)
			{
				SelectedCurrent.IsSelected = false;
			}

			SelectedCurrent = current;

		}
	}
}
