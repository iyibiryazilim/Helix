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
    public async Task OutCountingInsert([FromBody] OutCountingTransactionDto outCountingtransaction)
    {
        _eventBus.Publish(new OutCountingTransactionInsertingIntegrationEvent(outCountingtransaction.referenceId, outCountingtransaction.transactionDate, outCountingtransaction.transactionTime, outCountingtransaction.convertedTime, outCountingtransaction.orderReference, outCountingtransaction.code, outCountingtransaction.groupType, outCountingtransaction.iOType, outCountingtransaction.transactionType, outCountingtransaction.transactionTypeName, outCountingtransaction.warehouseNumber, outCountingtransaction.currentReferenceId, outCountingtransaction.currentCode, outCountingtransaction.total, outCountingtransaction.totalVat, outCountingtransaction.netTotal, outCountingtransaction.description, outCountingtransaction.dispatchType, outCountingtransaction.carrierReferenceId, outCountingtransaction.carrierCode, outCountingtransaction.driverReferenceId, outCountingtransaction.driverFirstName, outCountingtransaction.driverLastName, outCountingtransaction.identityNumber, outCountingtransaction.plaque, outCountingtransaction.shipInfoReferenceId, outCountingtransaction.shipInfoCode, outCountingtransaction.shipInfoName, outCountingtransaction.speCode, outCountingtransaction.dispatchStatus, outCountingtransaction.isEDispatch, outCountingtransaction.doCode, outCountingtransaction.docTrackingNumber, outCountingtransaction.isEInvoice, outCountingtransaction.eDispatchProfileId, outCountingtransaction.eInvoiceProfileId));

    }
}
