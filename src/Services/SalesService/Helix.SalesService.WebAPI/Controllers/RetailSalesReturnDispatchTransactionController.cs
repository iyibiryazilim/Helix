using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
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
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetAll()
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync();
		return result;
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
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentId(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code);
		return result;
	}
	[HttpPost]
	public async Task RetailSalesReturnDispatchTransactionInsert([FromBody] RetailSalesReturnDispatchTransactionDto retailSalesReturnDispatchTransactionDto)
	{
		_eventBus.Publish(new RetailSalesReturnDispatchTransactionInsertingIntegrationEvent(retailSalesReturnDispatchTransactionDto.referenceId, retailSalesReturnDispatchTransactionDto.transactionDate, retailSalesReturnDispatchTransactionDto.transactionTime, retailSalesReturnDispatchTransactionDto.convertedTime, retailSalesReturnDispatchTransactionDto.orderReference, retailSalesReturnDispatchTransactionDto.code, retailSalesReturnDispatchTransactionDto.groupType, retailSalesReturnDispatchTransactionDto.iOType, retailSalesReturnDispatchTransactionDto.transactionType, retailSalesReturnDispatchTransactionDto.transactionTypeName, retailSalesReturnDispatchTransactionDto.warehouseNumber, retailSalesReturnDispatchTransactionDto.currentReferenceId, retailSalesReturnDispatchTransactionDto.currentCode, retailSalesReturnDispatchTransactionDto.total, retailSalesReturnDispatchTransactionDto.totalVat, retailSalesReturnDispatchTransactionDto.netTotal, retailSalesReturnDispatchTransactionDto.description, retailSalesReturnDispatchTransactionDto.dispatchType, retailSalesReturnDispatchTransactionDto.carrierReferenceId, retailSalesReturnDispatchTransactionDto.carrierCode, retailSalesReturnDispatchTransactionDto.driverReferenceId, retailSalesReturnDispatchTransactionDto.driverFirstName, retailSalesReturnDispatchTransactionDto.driverLastName, retailSalesReturnDispatchTransactionDto.identityNumber, retailSalesReturnDispatchTransactionDto.plaque, retailSalesReturnDispatchTransactionDto.shipInfoReferenceId, retailSalesReturnDispatchTransactionDto.shipInfoCode, retailSalesReturnDispatchTransactionDto.shipInfoName, retailSalesReturnDispatchTransactionDto.speCode, retailSalesReturnDispatchTransactionDto.dispatchStatus, retailSalesReturnDispatchTransactionDto.isEDispatch, retailSalesReturnDispatchTransactionDto.doCode, retailSalesReturnDispatchTransactionDto.docTrackingNumber, retailSalesReturnDispatchTransactionDto.isEInvoice, retailSalesReturnDispatchTransactionDto.eDispatchProfileId, retailSalesReturnDispatchTransactionDto.eInvoiceProfileId));

	}
}
