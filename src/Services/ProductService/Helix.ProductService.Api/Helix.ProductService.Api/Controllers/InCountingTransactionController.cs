﻿using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Dtos;
using Helix.ProductService.Domain.Events;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class InCountingTransactionController : ControllerBase
{
	IInCountingTransactionService _inCountingTransactionService;
    IEventBus _eventBus;
    public InCountingTransactionController(IInCountingTransactionService inCountingTransactionService, IEventBus eventBus)
	{
		_inCountingTransactionService = inCountingTransactionService;
        _eventBus = eventBus;
    }


	[HttpGet]
	public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetAll()
	{
		var result = await _inCountingTransactionService.GetInCountingTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<InCountingTransaction>> GetById(int id)
	{
		var result = await _inCountingTransactionService.GetInCountingTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<InCountingTransaction>> GetByCode(string code)
	{
		var result = await _inCountingTransactionService.GetInCountingTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetByCurrentId(int id)
	{
		var result = await _inCountingTransactionService.GetInCountingTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _inCountingTransactionService.GetInCountingTransactionsByCurrentCodeAsync(code);
		return result;
	}

	[HttpPost]
	public async Task InCountingInsert([FromBody] InCountingTransactionDto inCountingtransaction)
	{
		_eventBus.Publish(new InCountingTransactionInsertingIntegrationEvent(inCountingtransaction.referenceId, inCountingtransaction.transactionDate, inCountingtransaction.transactionTime, inCountingtransaction.convertedTime, inCountingtransaction.orderReference, inCountingtransaction.code, inCountingtransaction.groupType, inCountingtransaction.iOType, inCountingtransaction.transactionType, inCountingtransaction.transactionTypeName, inCountingtransaction.warehouseNumber, inCountingtransaction.currentReferenceId, inCountingtransaction.currentCode, inCountingtransaction.total, inCountingtransaction.totalVat, inCountingtransaction.netTotal, inCountingtransaction.description, inCountingtransaction.dispatchType, inCountingtransaction.carrierReferenceId, inCountingtransaction.carrierCode, inCountingtransaction.driverReferenceId, inCountingtransaction.driverFirstName, inCountingtransaction.driverLastName, inCountingtransaction.identityNumber, inCountingtransaction.plaque, inCountingtransaction.shipInfoReferenceId, inCountingtransaction.shipInfoCode, inCountingtransaction.shipInfoName, inCountingtransaction.speCode, inCountingtransaction.dispatchStatus, inCountingtransaction.isEDispatch, inCountingtransaction.doCode, inCountingtransaction.docTrackingNumber, inCountingtransaction.isEInvoice, inCountingtransaction.eDispatchProfileId, inCountingtransaction.eInvoiceProfileId));

    }
}
