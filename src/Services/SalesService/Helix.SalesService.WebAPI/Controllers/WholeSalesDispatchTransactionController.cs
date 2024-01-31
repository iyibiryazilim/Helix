using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WholeSalesDispatchTransactionController : ControllerBase
{
	IWholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
	IEventBus _eventBus;
    public WholeSalesDispatchTransactionController(IWholeSalesDispatchTransactionService wholeSalesDispatchTransactionService,IEventBus eventBus)
    {
        _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
		_eventBus = eventBus;
    }
	[HttpGet]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetAll([FromQuery] string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, WholeSalesDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync(search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesDispatchTransaction>> GetById(int id)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<WholeSalesDispatchTransaction>> GetByCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, WholeSalesDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, WholeSalesDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
	[HttpPost]
	public async Task WholeSalesDispatchTransactionInsert([FromBody] WholeSalesDispatchTransactionDto wholeSalesDispatchTransactionDto)
	{
		_eventBus.Publish(new WholeSalesDispatchTransactionInsertingIntegrationEvent(wholeSalesDispatchTransactionDto.referenceId, wholeSalesDispatchTransactionDto.transactionDate, wholeSalesDispatchTransactionDto.transactionTime, wholeSalesDispatchTransactionDto.convertedTime, wholeSalesDispatchTransactionDto.orderReference, wholeSalesDispatchTransactionDto.code, wholeSalesDispatchTransactionDto.groupType, wholeSalesDispatchTransactionDto.iOType, wholeSalesDispatchTransactionDto.transactionType, wholeSalesDispatchTransactionDto.transactionTypeName, wholeSalesDispatchTransactionDto.warehouseNumber, wholeSalesDispatchTransactionDto.currentReferenceId, wholeSalesDispatchTransactionDto.currentCode, wholeSalesDispatchTransactionDto.total, wholeSalesDispatchTransactionDto.totalVat, wholeSalesDispatchTransactionDto.netTotal, wholeSalesDispatchTransactionDto.description, wholeSalesDispatchTransactionDto.dispatchType, wholeSalesDispatchTransactionDto.carrierReferenceId, wholeSalesDispatchTransactionDto.carrierCode, wholeSalesDispatchTransactionDto.driverReferenceId, wholeSalesDispatchTransactionDto.driverFirstName, wholeSalesDispatchTransactionDto.driverLastName, wholeSalesDispatchTransactionDto.identityNumber, wholeSalesDispatchTransactionDto.plaque, wholeSalesDispatchTransactionDto.shipInfoReferenceId, wholeSalesDispatchTransactionDto.shipInfoCode, wholeSalesDispatchTransactionDto.shipInfoName, wholeSalesDispatchTransactionDto.speCode, wholeSalesDispatchTransactionDto.dispatchStatus, wholeSalesDispatchTransactionDto.isEDispatch, wholeSalesDispatchTransactionDto.doCode, wholeSalesDispatchTransactionDto.docTrackingNumber, wholeSalesDispatchTransactionDto.isEInvoice, wholeSalesDispatchTransactionDto.eDispatchProfileId, wholeSalesDispatchTransactionDto.eInvoiceProfileId));

	}
}
