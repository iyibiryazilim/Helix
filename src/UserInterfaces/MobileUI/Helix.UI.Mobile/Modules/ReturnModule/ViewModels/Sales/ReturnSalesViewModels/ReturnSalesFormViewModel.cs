using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
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
	string transactionType;

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
	private readonly IServiceProvider _serviceProvider;
	private readonly ICustomerService _customerService;
	private readonly IRetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
	private readonly IWholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;

	// Constructor with dependency injection
	public ReturnSalesFormViewModel(
		IHttpClientService httpClientService,
		IWarehouseService warehouseService,
		ISpeCodeService speCodeService,
		ICustomerService customerService,
		IRetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService,
		IWholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService,
		IServiceProvider serviceProvider)
	{
		_httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
		_warehouseService = warehouseService ?? throw new ArgumentNullException(nameof(warehouseService));
		_speCodeService = speCodeService ?? throw new ArgumentNullException(nameof(speCodeService));
		_customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
		_retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService ?? throw new ArgumentNullException(nameof(retailSalesReturnDispatchTransactionService));
		_wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService ?? throw new ArgumentNullException(nameof(wholeSalesReturnDispatchTransactionService));
		_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

		Title = "Satış İade Formu";
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

    async Task RetailSalesReturnDispatchTransactionInsertAsync()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");


            RetailSalesReturnDispatchTransactionInsertDto dto = new RetailSalesReturnDispatchTransactionInsertDto();
            dto.WarehouseNumber = Warehouse.Number;
            dto.TransactionDate = PurchaseFormModel.TransactionDate;
            dto.TransactionType = 2;
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            dto.Description = PurchaseFormModel.Description;
            dto.CurrentCode = PurchaseFormModel.Customer.Code;
            dto.CurrentReferenceId = PurchaseFormModel.Customer.ReferenceId;
            dto.EmployeeOid = employeeOid;

            foreach (var item in ProductModel)
            {
                RetailSalesReturnDispatchTransactionLineDto lineDto = new RetailSalesReturnDispatchTransactionLineDto();

                lineDto.ProductCode = item.Code;
                lineDto.ProductReferenceId = item.ReferenceId;
                lineDto.CurrentCode = PurchaseFormModel.Customer.Code;
                lineDto.CurrentReferenceId = PurchaseFormModel.Customer.ReferenceId;
                lineDto.Quantity = item.Quantity;
                lineDto.UnitsetCode = item.UnitsetCode;
                lineDto.UnitsetReferenceId = item.UnitsetReferenceId;
                lineDto.TransactionType = 2;
                lineDto.SubUnitsetCode = item.SubUnitsetCode;
                lineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                lineDto.DispatchReferenceId = item.ReferenceId;
                lineDto.WarehouseNumber = Warehouse.Number;
                dto.Lines.Add(lineDto);
            }

            var result = await _retailSalesReturnDispatchTransactionService.InsertObject(httpClient, dto);
            if (result.IsSuccess)
            {
                var userResponse = await Shell.Current.DisplayAlert("Uyarı", "İşleminiz kaydedilecektir devam etmek istiyor musunuz?", "Evet", "Hayır");

                if (userResponse)
                {
                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 3,
                        ["SuccessMessage"] = "İade İrsaliyesi Başarıyla Gönderildi."
                    });
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Hata", ex.Message.ToString(), "Tamam");
            //return ex.ToString();
        }
        finally
        {
            IsBusy = false;
        }
    }

    async Task WholeSalesReturnDispatchTransactionInsertAsync()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            var employeeOid = await SecureStorage.GetAsync("EmployeeOid");

            WholeSalesReturnTransactionInsertDto _dto = new WholeSalesReturnTransactionInsertDto();
            _dto.WarehouseNumber = Warehouse.Number;
            _dto.TransactionDate = PurchaseFormModel.TransactionDate;
            _dto.TransactionType = 3;
            //retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
            _dto.Description = PurchaseFormModel.Description;
            _dto.CurrentCode = PurchaseFormModel.Customer.Code;
            _dto.CurrentReferenceId = PurchaseFormModel.Customer.ReferenceId;
            _dto.EmployeeOid = employeeOid;

            foreach (var item in ProductModel)
            {
                WholeSalesReturnTransactionLineDto lineDto = new WholeSalesReturnTransactionLineDto();

                lineDto.ProductCode = item.Code;
                lineDto.ProductReferenceId = item.ReferenceId;
                lineDto.CurrentCode = PurchaseFormModel.Customer.Code;
                lineDto.CurrentReferenceId = PurchaseFormModel.Customer.ReferenceId;
                lineDto.Quantity = item.Quantity;
                lineDto.UnitsetCode = item.UnitsetCode;
                lineDto.UnitsetReferenceId = item.UnitsetReferenceId;
                lineDto.TransactionType = 3;
                lineDto.SubUnitsetCode = item.SubUnitsetCode;
                lineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
                lineDto.DispatchReferenceId = item.ReferenceId;
                lineDto.WarehouseNumber = Warehouse.Number;
                _dto.Lines.Add(lineDto);
            }

            var result = await _wholeSalesReturnDispatchTransactionService.InsertObject(httpClient, _dto);
            if (result.IsSuccess)
            {
                await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                {
                    ["GroupType"] = 3,
                    ["SuccessMessage"] = "İade İrsaliyesi Başarıyla Gönderildi."

                });
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Hata", ex.Message.ToString(), "Tamam");
            //return ex.ToString();
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task ReturnDispatchInsert()
    {
        try
        {
            IsBusy = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            switch (TransactionType)
            {
                case "Parakende Satış İade İrsaliyesi":
                    await RetailSalesReturnDispatchTransactionInsertAsync();
                    break;
                case "Toptan Satış İade İrsaliyesi":
                    await WholeSalesReturnDispatchTransactionInsertAsync();
                    break;
                default:
                    break;
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Hata", ex.Message.ToString(), "Tamam");
            //return ex.ToString();
        }
        finally
        {
            IsBusy = false;
        }
    }
}