using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Dtos;
using Helix.ProductionService.Domain.Events;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductionTransactionController : ControllerBase
	{
		IProductionTransactionService _productionTransactionService;
		IEventBus _eventBus;

		public ProductionTransactionController(IProductionTransactionService productionTransactionService, IEventBus eventBus)
		{
			_productionTransactionService = productionTransactionService;
			_eventBus = eventBus;
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

		[HttpGet("Product/Code/{code}")]
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
		public async Task InsertProductionTransaction([FromBody] ProductionTransactionDto productionTransactionDto)
		{
			_eventBus.Publish(new ProductionTransactionInsertingIntegrationEvent(referenceId: productionTransactionDto.referenceId, transactionDate: productionTransactionDto.transactionDate,
			  transactionTime: productionTransactionDto.transactionTime,
			  convertedTime: productionTransactionDto.convertedTime,
			  orderReference: productionTransactionDto.orderReference,
			  code: productionTransactionDto.code,
			  groupType: productionTransactionDto.groupType,
			  iOType: productionTransactionDto.iOType,
			  transactionType: productionTransactionDto.transactionType,
			  transactionTypeName: productionTransactionDto.transactionTypeName,
			  warehouseNumber: productionTransactionDto.warehouseNumber,
			  currentReferenceId: productionTransactionDto.currentReferenceId,
			  currentCode: productionTransactionDto.currentCode,
			  total: productionTransactionDto.total,
			  totalVat: productionTransactionDto.totalVat,
			  netTotal: productionTransactionDto.netTotal,
			  description: productionTransactionDto.description,
			  dispatchType: productionTransactionDto.dispatchType,
			  carrierReferenceId: productionTransactionDto.carrierReferenceId,
			  carrierCode: productionTransactionDto.carrierCode,
			  driverReferenceId: productionTransactionDto.driverReferenceId,
			  driverFirstName: productionTransactionDto.driverFirstName,
			  driverLastName: productionTransactionDto.driverLastName,
			  identityNumber: productionTransactionDto.identityNumber,
			  plaque: productionTransactionDto.plaque,
			  shipInfoReferenceId: productionTransactionDto.shipInfoReferenceId,
			  shipInfoCode: productionTransactionDto.shipInfoCode,
			  shipInfoName: productionTransactionDto.shipInfoName,
			  speCode: productionTransactionDto.speCode,
			  dispatchStatus: productionTransactionDto.dispatchStatus,
			  isEDispatch: productionTransactionDto.isEDispatch,
			  doCode: productionTransactionDto.doCode,
			  docTrackingNumber: productionTransactionDto.docTrackingNumber,
			  isEInvoice: productionTransactionDto.isEInvoice,
			  eDispatchProfileId: productionTransactionDto.eDispatchProfileId,
			  eInvoiceProfileId: productionTransactionDto.eInvoiceProfileId,
			  lines: productionTransactionDto.lines
			  ));
		}
	}
}
