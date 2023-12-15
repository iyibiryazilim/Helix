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
public class ProductionTransactionController : ControllerBase
{
	IProductionTransactionService _productionTransactionService;
	IEventBus _eventBus;
	public ProductionTransactionController(IProductionTransactionService productionTransactionService, IEventBus eventbus)
	{
		_productionTransactionService = productionTransactionService;
		_eventBus = eventbus;
	}


	[HttpGet]
	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetAll()
	{
		var result = await _productionTransactionService.GetProductionTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<ProductionTransaction>> GetById(int id)
	{
		var result = await _productionTransactionService.GetProductionTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<ProductionTransaction>> GetByCode(string code)
	{
		var result = await _productionTransactionService.GetProductionTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetByCurrentId(int id)
	{
		var result = await _productionTransactionService.GetProductionTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _productionTransactionService.GetProductionTransactionsByCurrentCodeAsync(code);
		return result;
	}

	[HttpPost]
	public async Task ProductionTransactionInsert([FromBody] ProductionTransactionDto productionTransactionDto)
	{
		_eventBus.Publish(new ProductionTransactionInsertedIntegrationEvent(productionTransactionDto.referenceId, productionTransactionDto.transactionDate, productionTransactionDto.transactionTime, productionTransactionDto.convertedTime, productionTransactionDto.orderReference, productionTransactionDto.code, productionTransactionDto.groupType, productionTransactionDto.iOType, productionTransactionDto.transactionType, productionTransactionDto.transactionTypeName, productionTransactionDto.warehouseNumber, productionTransactionDto.currentReferenceId, productionTransactionDto.currentCode, productionTransactionDto.total, productionTransactionDto.totalVat, productionTransactionDto.netTotal, productionTransactionDto.description, productionTransactionDto.dispatchType, productionTransactionDto.carrierReferenceId, productionTransactionDto.carrierCode, productionTransactionDto.driverReferenceId, productionTransactionDto.driverFirstName, productionTransactionDto.driverLastName, productionTransactionDto.identityNumber, productionTransactionDto.plaque, productionTransactionDto.shipInfoReferenceId, productionTransactionDto.shipInfoCode, productionTransactionDto.shipInfoName, productionTransactionDto.speCode, productionTransactionDto.dispatchStatus, productionTransactionDto.isEDispatch, productionTransactionDto.doCode, productionTransactionDto.docTrackingNumber, productionTransactionDto.isEInvoice, productionTransactionDto.eDispatchProfileId, productionTransactionDto.eInvoiceProfileId));
	}

}
