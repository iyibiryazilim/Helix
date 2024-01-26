using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
[QueryProperty(name: nameof(ChangedLines), queryId: nameof(ChangedLines))]
public partial class DispatchByPurchaseOrderLineFormViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IWarehouseService _warehouseService;
	ISupplierService _supplierService;
	ISpeCodeService _speCodeService;

	public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
	public ObservableCollection<Supplier> SupplierItems { get; } = new();

	public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

	[ObservableProperty]
	ObservableCollection<WaitingOrderLine> changedLines;
	[ObservableProperty]
	ObservableCollection<ProductModel> productModel;
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	ProductOrderBy orderBy = ProductOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20000;
	[ObservableProperty]
	WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
	[ObservableProperty]
	SupplierOrderBy supplierOrderBy = SupplierOrderBy.nameasc;

	[ObservableProperty]
	PurchaseFormModel purchaseFormFormModel = new();

	[ObservableProperty]
	public string speCode = string.Empty;



	public DispatchByPurchaseOrderLineFormViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService, ISupplierService supplierService, ISpeCodeService speCodeService)
	{
		Title = "Satınalma İrsaliye Formu";
		_httpClientService = httpClientService;
		_warehouseService = warehouseService;
		_supplierService = supplierService;
		_speCodeService = speCodeService;
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

	[RelayCommand]
	public async Task GetWarehouseAsync()
	{

		try
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _warehouseService.GetObjects(httpClient, SearchText, WarehouseOrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				WarehouseItems.Clear();

				foreach (var item in result.Data)
				{
					await Task.Delay(100);
					WarehouseItems.Add(item);
				}
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

	[RelayCommand]
	public async Task GetSupplierAsync()
	{
		try
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			CurrentPage = 0;
			var result = await _supplierService.GetObjects(httpClient, SearchText, SupplierOrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				SupplierItems.Clear();

				foreach (var item in result.Data)
				{
					await Task.Delay(100);
					SupplierItems.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error:", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
