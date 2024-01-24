using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels
{
	public partial class DispatchByPurchaseOrderLineSupplierViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		private readonly ISupplierService _supplierService;
		//Lists
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
		int pageSize = 3000;

		//Lists
		public ObservableCollection<Current> Items { get; } = new();
		public ObservableCollection<Current> Result { get; } = new();


		public DispatchByPurchaseOrderLineSupplierViewModel(IHttpClientService httpClientService, ISupplierService supplierService)
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
				await MainThread.InvokeOnMainThreadAsync(GetSupplierAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task GetSupplierAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				IsRefreshing = false;

				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _supplierService.GetObjects(httpClient, "", OrderBy, CurrentPage, PageSize);
				if (result.IsSuccess)
				{
					if (Items.Any())
					{
						Items.Clear();
						Result.Clear();
					}

					foreach (var item in result.Data)
					{
						if (item.ReferenceCount > 0)
						{
							Items.Add(item);
							Result.Add(item);
						}
					}
				}
				else
				{
					await Shell.Current.DisplayAlert(" Error: ", $"{result.Message}", "Tamam");

				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
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
						foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText)))
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
		async Task ToggleSelectionAsync(Current item)
		{
			// Deselect all items
			foreach (var currentItem in Items)
			{
				currentItem.IsSelected = false;
			}

			// Toggle the selection of the provided item
			item.IsSelected = !item.IsSelected;
		}

		[RelayCommand]
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A", "Referans Sayısı A-Z", "Referans Sayısı Z-A");
				if (!string.IsNullOrEmpty(response))
				{
					CurrentPage = 0;
					await Task.Delay(100);
					switch (response)
					{
						case "Kod A-Z":
							OrderBy = SupplierOrderBy.codeasc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.Code))
							{
								Result.Add(item);
							}
							break;
						case "Kod Z-A":
							OrderBy = SupplierOrderBy.codedesc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.Code))
							{
								Result.Add(item);
							}
							break;
						case "Ad A-Z":
							OrderBy = SupplierOrderBy.nameasc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.Name))
							{
								Result.Add(item);
							}
							break;
						case "Ad Z-A":
							OrderBy = SupplierOrderBy.namedesc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.Name))
							{
								Result.Add(item);
							}
							break;
						case "Referans Sayısı A-Z":
							OrderBy = SupplierOrderBy.nameasc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderBy(x => x.ReferenceCount))
							{
								Result.Add(item);
							}
							break;
						case "Referans Sayısı Z-A":
							OrderBy = SupplierOrderBy.namedesc;
							Result.Clear();
							foreach (var item in Items.ToList().OrderByDescending(x => x.ReferenceCount))
							{
								Result.Add(item);
							}
							break;
						default:
							foreach (var item in Items.ToList().OrderBy(x => x.Name))
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
		async Task GoToFicheListAsync()
		{
			try
			{
				if (Items.Where(c => c.IsSelected).Any())
				{
					var result = Items.Where(c => c.IsSelected).First();
					await Task.Delay(500);
					await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineWarehouseListView)}", new Dictionary<string, object>
					{
						[nameof(Current)] = result
					});
				}
				else
				{
					await Shell.Current.DisplayAlert("Uyarı", "Tedarikçi Seçiniz", "Tamam");

				}

			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
		}


	}
}
