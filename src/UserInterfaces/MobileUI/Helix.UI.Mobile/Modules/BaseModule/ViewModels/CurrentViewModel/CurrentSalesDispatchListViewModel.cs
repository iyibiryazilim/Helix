using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.ViewModels.CurrentViewModel
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class CurrentSalesDispatchListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ISupplierTransactionLineService _supplierTransactionLineService;


		[ObservableProperty]
		Customer current;

		public CurrentSalesDispatchListViewModel(ISupplierTransactionLineService supplierTransactionLineService, IHttpClientService httpClientService)
		{
			Title = "Satış İrsaliyeleri";
			_httpClientService = httpClientService;
			_supplierTransactionLineService = supplierTransactionLineService;

			GetLoadDataCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		}
		//Lists
		public ObservableCollection<CurrentTransactionLine> Items { get; } = new();
		//Commands
		public Command GetLoadDataCommand { get; }
		public Command SearchCommand { get; }
		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		SupplierTransactionLineOrderBy orderBy = SupplierTransactionLineOrderBy.nameasc;
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
				var result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, "7,8", CurrentPage, PageSize);
				if (result.Data.Any())
				{
					foreach (var item in result.Data)
					{
						await Task.Delay(50);
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

			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				CurrentPage = 0;
				var result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, "7,8", CurrentPage, PageSize);
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
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A", "Tarih A-Z", "Tarih Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Kod A-Z":
							OrderBy = SupplierTransactionLineOrderBy.codeasc;
							await ReloadAsync();
							break;
						case "Kod Z-A":
							OrderBy = SupplierTransactionLineOrderBy.codedesc;
							await ReloadAsync();
							break;
						case "Ad A-Z":
							OrderBy = SupplierTransactionLineOrderBy.nameasc;
							await ReloadAsync();
							break;
						case "Ad Z-A":
							OrderBy = SupplierTransactionLineOrderBy.namedesc;
							await ReloadAsync();
							break;
						case "Tarih A-Z":
							OrderBy = SupplierTransactionLineOrderBy.dateasc;
							await ReloadAsync();
							break;
						case "Tarih Z-A":
							OrderBy = SupplierTransactionLineOrderBy.datedesc;
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

		[RelayCommand]
		async Task GoToBackAsync()
		{
			try
			{
				IsBusy = true;
				await Shell.Current.GoToAsync($"..");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
