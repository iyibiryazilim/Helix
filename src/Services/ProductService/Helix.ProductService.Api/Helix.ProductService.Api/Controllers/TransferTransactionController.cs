using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Dtos;
using Helix.ProductService.Domain.Events;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TransferTransactionController : ControllerBase
{
	ITransferTransactionService _transferTransactionService;
	IEventBus _eventbus;
	public TransferTransactionController(ITransferTransactionService transferTransactionService, IEventBus eventBus)
	{
		_transferTransactionService = transferTransactionService;
		_eventbus = eventBus;
	}


	[HttpGet]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetAll()
	{
		var result = await _transferTransactionService.GetTransferTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<TransferTransaction>> GetById(int id)
	{
		var result = await _transferTransactionService.GetTransferTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<TransferTransaction>> GetByCode(string code)
	{
		var result = await _transferTransactionService.GetTransferTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetByCurrentId(int id)
	{
		var result = await _transferTransactionService.GetTransferTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _transferTransactionService.GetTransferTransactionsByCurrentCodeAsync(code);
		return result;
	}

	[HttpPost]
	public async Task TransferTransactionInsert([FromBody] TransferTransactionDto transferTransactionDto)
	{
		_eventbus.Publish(new TransferTransactionInsertingIntegrationEvent(transferTransactionDto.referenceId, transferTransactionDto.transactionDate, transferTransactionDto.code, transferTransactionDto.groupType, transferTransactionDto.iOType, transferTransactionDto.transactionType, transferTransactionDto.warehouseNumber,transferTransactionDto.destinationWarehouseNumber, transferTransactionDto.currentReferenceId, transferTransactionDto.currentCode, transferTransactionDto.description, transferTransactionDto.speCode, transferTransactionDto.doCode, transferTransactionDto.docTrackingNumber, transferTransactionDto.lines)); 
	}
}
