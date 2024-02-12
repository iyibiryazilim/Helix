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
public class OutCountingTransactionController : ControllerBase
{
	IOutCountingTransactionService _outCountingTransactionService;
    IEventBus _eventBus;
    public OutCountingTransactionController(IOutCountingTransactionService outCountingTransactionService , IEventBus eventBus)
	{
		_outCountingTransactionService = outCountingTransactionService;
		_eventBus = eventBus;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetAll()
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<OutCountingTransaction>> GetById(int id)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<OutCountingTransaction>> GetByCode(string code)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetByCurrentId(int id)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsByCurrentCodeAsync(code);
		return result;
	}
    [HttpPost]
    public async Task OutCountingInsert([FromBody] OutCountingTransactionDto outCountingTransaction)
    {
        _eventBus.Publish(new OutCountingTransactionInsertingIntegrationEvent(outCountingTransaction.referenceId, outCountingTransaction.transactionDate, outCountingTransaction.code, outCountingTransaction.groupType, outCountingTransaction.iOType, outCountingTransaction.transactionType, outCountingTransaction.warehouseNumber, outCountingTransaction.currentReferenceId, outCountingTransaction.currentCode, outCountingTransaction.description, outCountingTransaction.speCode, outCountingTransaction.doCode, outCountingTransaction.docTrackingNumber, outCountingTransaction.lines));

    }
}
