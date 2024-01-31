using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

public partial class ReturnSalesFormViewModel : BaseViewModel
{
	public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
	public ObservableCollection<Customer> CustomerList { get; } = new();

	[ObservableProperty]
	string transactionTypeName;

	[ObservableProperty]
	PurchaseFormModel productTransactionFormModel = new();


	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 5000;
	[ObservableProperty]
	WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;

	[ObservableProperty]
	Warehouse warehouse;
	[ObservableProperty]
	ObservableCollection<ProductModel> productModel;
	[ObservableProperty]
	PurchaseFormModel purchaseFormModel = new();
	public Command GetCustomersCommand { get; }

	//speCode
	[ObservableProperty]
	public string speCode = string.Empty;

	public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

	private readonly IHttpClientService _httpClientService;
	private readonly IWarehouseService _warehouseService;
	private readonly ISpeCodeService _speCodeService;
	private readonly ICustomerService _customerService;

	// Constructor with dependency injection
	public ReturnSalesFormViewModel(
		IHttpClientService httpClientService,
		IWarehouseService warehouseService,
		ISpeCodeService speCodeService,
		ICustomerService customerService)
	{
		_httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
		_warehouseService = warehouseService ?? throw new ArgumentNullException(nameof(warehouseService));
		_speCodeService = speCodeService ?? throw new ArgumentNullException(nameof(speCodeService));
		_customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));

		Title = "Satış İade Fişleri";
		GetCustomersCommand = new Command(async () => await LoadData());
	}
	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetCustomersAsync);

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
	[RelayCommand]
	public async Task GetSpeCodeAsync()
	{
		string action;

		try
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _speCodeService.GetObjects(httpClient);

			if (result.Data.Any())
			{
				SpeCodeModelItems.Clear();

				foreach (var item in result.Data)
				{
					SpeCodeModelItems.Add(item);
				}

				List<string> speCodeStrings = SpeCodeModelItems.Select(code => code.SpeCode).ToList();

				action = await Shell.Current.DisplayActionSheet("Özel Kod:", "Vazgeç", null, speCodeStrings.ToArray());

				SpeCode = action;


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

		}
	}

	async Task GetCustomersAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();

			var result = await _customerService.GetObjects(httpClient, "", CustomerOrderBy.namedesc, CurrentPage, PageSize);
			if (result.IsSuccess)
			{
				if (result.Data.Any())
				{
					CustomerList.Clear();
					foreach (var item in result.Data)
					{
						CustomerList.Add(item);
					}
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Customer Error: ", $"{result.Message}", "Tamam");

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
	async Task GoToSuccessPageView()
	{
		await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
		{
			["GroupType"] = 3
		});
	}


}
