﻿using Helix.EventBus.Base.Abstractions;
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
public class RetailSalesReturnDispatchTransactionController : ControllerBase
{
	IRetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
	IEventBus _eventBus;
	public RetailSalesReturnDispatchTransactionController(IRetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService, IEventBus eventBus)
	{
		_retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService;
		_eventBus = eventBus;
	}
	[HttpGet]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetAll([FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync( search, RetailSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync(search, RetailSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync( search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetById(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetByCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id,search, RetailSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, RetailSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code,search, RetailSalesReturnDispatchOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, RetailSalesReturnDispatchOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
    [HttpPost]
    public async Task RetailSalesReturnDispatchTransactionInsert([FromBody] RetailSalesReturnDispatchTransactionDto retailSalesReturnDispatchTransactionDto)
    {
        _eventBus.Publish(new RetailSalesReturnDispatchTransactionInsertingIntegrationEvent(retailSalesReturnDispatchTransactionDto.referenceId, retailSalesReturnDispatchTransactionDto.transactionDate, retailSalesReturnDispatchTransactionDto.groupType, retailSalesReturnDispatchTransactionDto.iOType, retailSalesReturnDispatchTransactionDto.transactionType, retailSalesReturnDispatchTransactionDto.warehouseNumber, retailSalesReturnDispatchTransactionDto.currentReferenceId, retailSalesReturnDispatchTransactionDto.currentCode, retailSalesReturnDispatchTransactionDto.total, retailSalesReturnDispatchTransactionDto.totalVat, retailSalesReturnDispatchTransactionDto.netTotal, retailSalesReturnDispatchTransactionDto.description, retailSalesReturnDispatchTransactionDto.dispatchType, retailSalesReturnDispatchTransactionDto.speCode, retailSalesReturnDispatchTransactionDto.dispatchStatus, retailSalesReturnDispatchTransactionDto.isEDispatch, retailSalesReturnDispatchTransactionDto.doCode, retailSalesReturnDispatchTransactionDto.docTrackingNumber, retailSalesReturnDispatchTransactionDto.isEInvoice, retailSalesReturnDispatchTransactionDto.eDispatchProfileId, retailSalesReturnDispatchTransactionDto.eInvoiceProfileId,retailSalesReturnDispatchTransactionDto.employeeOid,retailSalesReturnDispatchTransactionDto.lines));

    }
}
