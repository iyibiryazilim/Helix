using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Domain.AggregateModels;
using Microsoft.AspNetCore.Mvc;
using Helix.ProductService.Domain.Dtos;
using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Events;
using Microsoft.AspNetCore.Authorization;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
		_eventBus.Publish(new ConsumableTransactionInsertingIntegrationEvent(consumableTransactionDto.referenceId, consumableTransactionDto.transactionDate, consumableTransactionDto.code, consumableTransactionDto.groupType, consumableTransactionDto.iOType, consumableTransactionDto.transactionType, consumableTransactionDto.warehouseNumber, consumableTransactionDto.currentReferenceId, consumableTransactionDto.currentCode,consumableTransactionDto.description,   consumableTransactionDto.speCode,consumableTransactionDto.doCode, consumableTransactionDto.docTrackingNumber,consumableTransactionDto.lines ));
	}
}
