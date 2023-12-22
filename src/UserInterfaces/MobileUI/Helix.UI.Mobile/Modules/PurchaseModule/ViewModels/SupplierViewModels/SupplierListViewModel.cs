using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels
{
	public partial class SupplierListViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ISupplierService _supplierService;
		//Lists
		public ObservableCollection<Current> Items { get; } = new();
		//Commands
		public Command GetSupplierCommand { get; }
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

		public SupplierListViewModel(IHttpClientService httpClientService, ISupplierService supplierService)
		{
			_httpClientService = httpClientService;
			_supplierService = supplierService;
			GetSupplierCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				//await MainThread.InvokeOnMainThreadAsync(ReloadAsync());
				await ReloadAsync();

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
			if(IsBusy)
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
						await Task.Delay(100);
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


	}
}
