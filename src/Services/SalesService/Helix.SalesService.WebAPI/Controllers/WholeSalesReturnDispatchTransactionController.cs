using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class WholeSalesReturnDispatchTransactionController : ControllerBase
	{
		IWholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;
		IEventBus _eventBus;
        public WholeSalesReturnDispatchTransactionController(IWholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService , IEventBus eventBus)
        {
            _wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService;
			_eventBus = eventBus;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetAll([FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, WholeSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync(search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetById(int id)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetByCode(string code)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>> result = new();
			switch (orderBy)
			{

				case "customernamedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				case "customernameasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				case "customercodedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				case "customercodeasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, orderBy, page, pageSize);
					return result;
			}
		}
        [HttpPost]
        public async Task WholeSalesReturnDispatchTransactionInsert([FromBody] WholeSalesReturnDispatchTransactionDto wholeSalesReturnDispatchTransactionDto)
        {
            _eventBus.Publish(new WholeSalesReturnDispatchTransactionInsertingIntegrationEvent(wholeSalesReturnDispatchTransactionDto.referenceId, wholeSalesReturnDispatchTransactionDto.transactionDate, wholeSalesReturnDispatchTransactionDto.groupType, wholeSalesReturnDispatchTransactionDto.iOType, wholeSalesReturnDispatchTransactionDto.transactionType, wholeSalesReturnDispatchTransactionDto.warehouseNumber, wholeSalesReturnDispatchTransactionDto.currentReferenceId, wholeSalesReturnDispatchTransactionDto.currentCode, wholeSalesReturnDispatchTransactionDto.total, wholeSalesReturnDispatchTransactionDto.totalVat, wholeSalesReturnDispatchTransactionDto.netTotal, wholeSalesReturnDispatchTransactionDto.description, wholeSalesReturnDispatchTransactionDto.dispatchType, wholeSalesReturnDispatchTransactionDto.speCode, wholeSalesReturnDispatchTransactionDto.dispatchStatus, wholeSalesReturnDispatchTransactionDto.isEDispatch, wholeSalesReturnDispatchTransactionDto.doCode, wholeSalesReturnDispatchTransactionDto.docTrackingNumber, wholeSalesReturnDispatchTransactionDto.isEInvoice, wholeSalesReturnDispatchTransactionDto.eDispatchProfileId, wholeSalesReturnDispatchTransactionDto.eInvoiceProfileId, wholeSalesReturnDispatchTransactionDto.lines));

        }
    }
}
