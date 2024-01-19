using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionLineViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels;

public partial class ReturnBySalesDispatchTransactionLineCustomerViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly ICustomerService _customerService;

	#region Commands
	public Command<string> SearchCommand { get; }
	public Command GetCustomersCommand { get; }
	#endregion

	public ReturnBySalesDispatchTransactionLineCustomerViewModel(IHttpClientService httpClientService, ICustomerService customerService)
	{
		Title = "Müşteri Listesi";
		_httpClientService = httpClientService;
		_customerService = customerService;

		SearchCommand = new Command<string>(async (searchText) => await PerformSearchCommand(searchText));
		GetCustomersCommand = new Command(async () => await LoadData());
	}

	#region Lists
	public ObservableCollection<Current> Items { get; } = new();

	public ObservableCollection<Current> Results { get; } = new();
	#endregion


	#region Properties
	[ObservableProperty]
	Current selectedCustomer;

	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	CustomerOrderBy orderBy = CustomerOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 5000;
	#endregion

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetCustomersListAsync);

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
	async Task GetCustomersListAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _customerService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();
				Results.Clear();
				foreach (var item in result.Data)
				{
					if (item.ReferenceCount > 0)
					{
						Items.Add(item);
						Results.Add(item);
					}

				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Retrieve Customer Data Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	async Task PerformSearchCommand(string text)
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
					foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText) || x.Name.Contains(SearchText)))
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
			await Shell.Current.DisplayAlert("Search Error: ", $"{ex.Message}", "Tamam");
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
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
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
					default:
						await GetCustomersListAsync();
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
	private void ToggleSelection(Current item)
	{
		item.IsSelected = !item.IsSelected;
		if (SelectedCustomer != null)
		{
			SelectedCustomer.IsSelected = false;
		}
		if (item.IsSelected)
		{
			SelectedCustomer = item;
		}
	}

    [RelayCommand]
    async Task GoToWarehouseAsync()
    {
        if (SelectedCustomer is not null)
        {
            await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionLineWarehouseListView)}", new Dictionary<string, object>
            {
                ["Current"] = SelectedCustomer
            });
        }
        else
        {
            await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Müşteri seçimi yapmanız gerekmektedir", "Tamam");
        }

    }

}
