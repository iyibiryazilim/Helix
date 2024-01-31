using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class RetailSalesDispatchTransactionController : ControllerBase
	{
		IRetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
		IEventBus _eventBus;
        public RetailSalesDispatchTransactionController(IRetailSalesDispatchTransactionService retailSalesDispatchTransactionService,IEventBus eventBus)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
			_eventBus = eventBus;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetAll([FromQuery] string search = "", string orderBy = RetailSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<RetailSalesDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, RetailSalesDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync(search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetById(int id)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetByCode(string code)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = RetailSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<RetailSalesDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id,search, RetailSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id,search, RetailSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id,search, RetailSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id,search, RetailSalesDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id,search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentCode(string code,[FromQuery] string search = "", string orderBy = RetailSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<RetailSalesDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpPost]
		public async Task RetailSalesDispatchTransactionInsert([FromBody] RetailSalesDispatchTransactionDto retailSalesDispatchTransactionDto)
		{
			_eventBus.Publish(new RetailSalesDispatchTransactionInsertingIntegrationEvent(retailSalesDispatchTransactionDto.referenceId, retailSalesDispatchTransactionDto.transactionDate,retailSalesDispatchTransactionDto.groupType, retailSalesDispatchTransactionDto.iOType, retailSalesDispatchTransactionDto.transactionType,  retailSalesDispatchTransactionDto.warehouseNumber, retailSalesDispatchTransactionDto.currentReferenceId, retailSalesDispatchTransactionDto.currentCode, retailSalesDispatchTransactionDto.total, retailSalesDispatchTransactionDto.totalVat, retailSalesDispatchTransactionDto.netTotal, retailSalesDispatchTransactionDto.description, retailSalesDispatchTransactionDto.dispatchType, retailSalesDispatchTransactionDto.carrierReferenceId, retailSalesDispatchTransactionDto.carrierCode, retailSalesDispatchTransactionDto.driverReferenceId, retailSalesDispatchTransactionDto.driverFirstName, retailSalesDispatchTransactionDto.driverLastName, retailSalesDispatchTransactionDto.identityNumber,retailSalesDispatchTransactionDto.plaque, retailSalesDispatchTransactionDto.shipInfoReferenceId, retailSalesDispatchTransactionDto.shipInfoCode, retailSalesDispatchTransactionDto.speCode, retailSalesDispatchTransactionDto.dispatchStatus, retailSalesDispatchTransactionDto.isEDispatch, retailSalesDispatchTransactionDto.doCode, retailSalesDispatchTransactionDto.docTrackingNumber, retailSalesDispatchTransactionDto.isEInvoice, retailSalesDispatchTransactionDto.eDispatchProfileId, retailSalesDispatchTransactionDto.eInvoiceProfileId,retailSalesDispatchTransactionDto.lines));

		}
	}
}
