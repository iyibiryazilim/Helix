using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	[QueryProperty(nameof(Warehouse), nameof(Warehouse))]
	[QueryProperty(nameof(ChangedLines), nameof(ChangedLines))]
	public partial class ReturnBySalesDispatchTransactionFormViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ISpeCodeService _speCodeService;
		IPurchaseDispatchTransactionService _purchaseDispatchTransaction;

		public ObservableCollection<Warehouse> WarehouseItems { get; } = new();
		public ObservableCollection<Customer> CustomerItems { get; } = new();


		[ObservableProperty]
		Customer current;

		[ObservableProperty]
		Warehouse warehouse;
		[ObservableProperty]
		ObservableCollection<DispatchTransactionLine> changedLines; 
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 5000;
		[ObservableProperty]
		WarehouseOrderBy warehouseOrderBy = WarehouseOrderBy.numberasc;
		[ObservableProperty]
		CustomerOrderBy customerOrderBy = CustomerOrderBy.nameasc;

		[ObservableProperty]
		PurchaseFormModel purchaseFormModel = new();
		//speCode
		[ObservableProperty]
		public string speCode = string.Empty;

		[ObservableProperty]
		public string transactionType = string.Empty;
	 
		public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();


		public ReturnBySalesDispatchTransactionFormViewModel(IHttpClientService httpClientService, ISpeCodeService speCodeService, IPurchaseDispatchTransactionService purchaseDispatchTransaction)
		{
			Title = "Satış Form";
			_httpClientService = httpClientService;

			_speCodeService = speCodeService;
			_purchaseDispatchTransaction = purchaseDispatchTransaction;

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
		async Task PurchaseDispatchInsert()
		{
			try
			{
				IsBusy = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				switch (TransactionType)
				{
					case "Parakende Satış İade İrsaliyesi":
						RetailSalesReturnDispatchTransactionInsertDto dto = new RetailSalesReturnDispatchTransactionInsertDto();
						dto.WarehouseNumber = Warehouse.Number;
						dto.TransactionDate = PurchaseFormModel.TransactionDate;
						dto.TransactionType = 1;
						//retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
						dto.Description = PurchaseFormModel.Description;
						dto.CurrentCode = ChangedLines.FirstOrDefault().CurrentCode;
						dto.CurrentReferenceId = ChangedLines.FirstOrDefault().CurrentReferenceId;

						foreach (var item in ChangedLines)
						{
							RetailSalesReturnDispatchTransactionLineDto lineDto = new RetailSalesReturnDispatchTransactionLineDto();

							lineDto.ProductCode = item.ProductCode;
							lineDto.ProductReferenceId = item.ProductReferenceId;
							lineDto.CurrentCode = item.CurrentCode;
							lineDto.CurrentReferenceId = item.CurrentReferenceId;
							lineDto.Quantity = item.Quantity;
							lineDto.UnitsetCode = item.UnitsetCode;
							lineDto.UnitsetReferenceId = item.UnitsetReferenceId;
							lineDto.TransactionType = 1;
							lineDto.SubUnitsetCode = item.SubUnitsetCode;
							lineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
							lineDto.DispatchReferenceId = item.ReferenceId;
							lineDto.WarehouseNumber = Warehouse.Number;
							dto.Lines.Add(lineDto);
						}
						break;
					case "Toptan Satış İade İrsaliyesi":
						WholeSalesReturnTransactionInsertDto _dto = new WholeSalesReturnTransactionInsertDto();
						_dto.WarehouseNumber = Warehouse.Number;
						_dto.TransactionDate = PurchaseFormModel.TransactionDate;
						_dto.TransactionType = 1;
						//retailSalesDispatch.IsEDispatch = (short)DispatchBySalesOrder.SelectedCustomer.DispatchType;
						_dto.Description = PurchaseFormModel.Description;
						_dto.CurrentCode = ChangedLines.FirstOrDefault().CurrentCode;
						_dto.CurrentReferenceId = ChangedLines.FirstOrDefault().CurrentReferenceId;

						foreach (var item in ChangedLines)
						{
							WholeSalesReturnTransactionLineDto lineDto = new WholeSalesReturnTransactionLineDto();

							lineDto.ProductCode = item.ProductCode;
							lineDto.ProductReferenceId = item.ProductReferenceId;
							lineDto.CurrentCode = item.CurrentCode;
							lineDto.CurrentReferenceId = item.CurrentReferenceId;
							lineDto.Quantity = item.Quantity;
							lineDto.UnitsetCode = item.UnitsetCode;
							lineDto.UnitsetReferenceId = item.UnitsetReferenceId;
							lineDto.TransactionType = 1;
							lineDto.SubUnitsetCode = item.SubUnitsetCode;
							lineDto.SubUnitsetReferenceId = item.SubUnitsetReferenceId;
							lineDto.DispatchReferenceId = item.ReferenceId;
							lineDto.WarehouseNumber = Warehouse.Number;
							_dto.Lines.Add(lineDto);
						}
						break;
					default:
						break;
				} 
				//var result = await _purchaseDispatchTransaction.InsertObject(httpClient, dto);
				//if (result.IsSuccess)
				//{
				//	await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
				//	{
				//		["GroupType"] = 1
				//	});
				//}
				//else
				//{
				//	await Shell.Current.DisplayAlert("Hata", result.Message, "Tamam");
				//}

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
}
