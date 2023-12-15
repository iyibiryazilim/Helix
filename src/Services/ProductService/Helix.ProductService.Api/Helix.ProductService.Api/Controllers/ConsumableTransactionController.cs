using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Domain.AggregateModels;
using Microsoft.AspNetCore.Mvc;
using Helix.ProductService.Domain.Dtos;
using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Events;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumableTransactionController : ControllerBase
{
	IConsumableTransactionService _consumableTransactionService;
	IEventBus _eventBus;
	public ConsumableTransactionController( IConsumableTransactionService consumableTransactionService, IEventBus eventBus)
	{
		_consumableTransactionService = consumableTransactionService;
        _eventBus = eventBus;
    }

	[HttpGet]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetAll()
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<ConsumableTransaction>> GetById(int id)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<ConsumableTransaction>> GetByCode(string code)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetByCurrentId(int id)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsByCurrentCodeAsync(code);
		return result;
	}
	[HttpPost]
	public async Task ConsumableTransactionInsert([FromBody] ConsumableTransactionDto consumableTransactionDto)
	{
		_eventBus.Publish(new ConsumableTransactionInsertedIntegrationEvent(consumableTransactionDto.referenceId, consumableTransactionDto.transactionDate, consumableTransactionDto.transactionTime, consumableTransactionDto.convertedTime, consumableTransactionDto.orderReference, consumableTransactionDto.code, consumableTransactionDto.groupType, consumableTransactionDto.iOType, consumableTransactionDto.transactionType, consumableTransactionDto.transactionTypeName, consumableTransactionDto.warehouseNumber, consumableTransactionDto.currentReferenceId, consumableTransactionDto.currentCode, consumableTransactionDto.total, consumableTransactionDto.totalVat, consumableTransactionDto.netTotal, consumableTransactionDto.description, consumableTransactionDto.dispatchType, consumableTransactionDto.carrierReferenceId, consumableTransactionDto.carrierCode, consumableTransactionDto.driverReferenceId, consumableTransactionDto.driverFirstName, consumableTransactionDto.driverLastName, consumableTransactionDto.identityNumber, consumableTransactionDto.plaque, consumableTransactionDto.shipInfoReferenceId, consumableTransactionDto.shipInfoCode, consumableTransactionDto.shipInfoName, consumableTransactionDto.speCode, consumableTransactionDto.dispatchStatus, consumableTransactionDto.isEDispatch, consumableTransactionDto.doCode, consumableTransactionDto.docTrackingNumber, consumableTransactionDto.isEInvoice, consumableTransactionDto.eDispatchProfileId, consumableTransactionDto.eInvoiceProfileId));
	}
}
