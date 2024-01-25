using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Dtos;
using Helix.ProductService.Domain.Events;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WastageTransactionController : ControllerBase
{
	IWastageTransactionService _wastageTransactionService;
	IEventBus _eventbus;
	public WastageTransactionController(IWastageTransactionService wastageTransactionService, IEventBus eventbus)
	{
		_wastageTransactionService = wastageTransactionService;
		_eventbus = eventbus;
	}


	[HttpGet]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetAll()
	{
		var result = await _wastageTransactionService.GetWastageTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WastageTransaction>> GetById(int id)
	{
		var result = await _wastageTransactionService.GetWastageTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<WastageTransaction>> GetByCode(string code)
	{
		var result = await _wastageTransactionService.GetWastageTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetByCurrentId(int id)
	{
		var result = await _wastageTransactionService.GetWastageTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _wastageTransactionService.GetWastageTransactionsByCurrentCodeAsync(code);
		return result;
	}
    [HttpPost]
    public async Task WastageTransactionInsert([FromBody] WastageTransactionDto wastageTransactionDto)
    {
        _eventbus.Publish(new WastageTransactionInsertingIntegrationEvent(wastageTransactionDto.referenceId, wastageTransactionDto.transactionDate, wastageTransactionDto.orderReference, wastageTransactionDto.code, wastageTransactionDto.groupType, wastageTransactionDto.iOType, wastageTransactionDto.transactionType, wastageTransactionDto.warehouseNumber, wastageTransactionDto.currentReferenceId, wastageTransactionDto.currentCode, wastageTransactionDto.description, wastageTransactionDto.speCode, wastageTransactionDto.doCode, wastageTransactionDto.docTrackingNumber, wastageTransactionDto.lines));
    }
}
