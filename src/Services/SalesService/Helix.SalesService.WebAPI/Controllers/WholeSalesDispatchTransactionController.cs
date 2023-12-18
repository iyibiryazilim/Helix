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
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetAll()
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync();
		return result;
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
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentId(int id)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code);
		return result;
	}
	[HttpPost]
	public async Task WholeSalesDispatchTransactionInsert([FromBody] WholeSalesDispatchTransactionDto wholeSalesDispatchTransactionDto)
	{
		_eventBus.Publish(new WholeSalesDispatchTransactionInsertingIntegrationEvent(wholeSalesDispatchTransactionDto.referenceId, wholeSalesDispatchTransactionDto.transactionDate, wholeSalesDispatchTransactionDto.transactionTime, wholeSalesDispatchTransactionDto.convertedTime, wholeSalesDispatchTransactionDto.orderReference, wholeSalesDispatchTransactionDto.code, wholeSalesDispatchTransactionDto.groupType, wholeSalesDispatchTransactionDto.iOType, wholeSalesDispatchTransactionDto.transactionType, wholeSalesDispatchTransactionDto.transactionTypeName, wholeSalesDispatchTransactionDto.warehouseNumber, wholeSalesDispatchTransactionDto.currentReferenceId, wholeSalesDispatchTransactionDto.currentCode, wholeSalesDispatchTransactionDto.total, wholeSalesDispatchTransactionDto.totalVat, wholeSalesDispatchTransactionDto.netTotal, wholeSalesDispatchTransactionDto.description, wholeSalesDispatchTransactionDto.dispatchType, wholeSalesDispatchTransactionDto.carrierReferenceId, wholeSalesDispatchTransactionDto.carrierCode, wholeSalesDispatchTransactionDto.driverReferenceId, wholeSalesDispatchTransactionDto.driverFirstName, wholeSalesDispatchTransactionDto.driverLastName, wholeSalesDispatchTransactionDto.identityNumber, wholeSalesDispatchTransactionDto.plaque, wholeSalesDispatchTransactionDto.shipInfoReferenceId, wholeSalesDispatchTransactionDto.shipInfoCode, wholeSalesDispatchTransactionDto.shipInfoName, wholeSalesDispatchTransactionDto.speCode, wholeSalesDispatchTransactionDto.dispatchStatus, wholeSalesDispatchTransactionDto.isEDispatch, wholeSalesDispatchTransactionDto.doCode, wholeSalesDispatchTransactionDto.docTrackingNumber, wholeSalesDispatchTransactionDto.isEInvoice, wholeSalesDispatchTransactionDto.eDispatchProfileId, wholeSalesDispatchTransactionDto.eInvoiceProfileId));

	}
}
