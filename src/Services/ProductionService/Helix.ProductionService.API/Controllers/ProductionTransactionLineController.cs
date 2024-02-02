using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Dtos;
using Helix.ProductionService.Domain.Events;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class ProductionTransactionLineController : ControllerBase
	{
		IProductionTransactionLineService _productionTransactionLineService;
		IEventBus _eventBus;

		public ProductionTransactionLineController(IProductionTransactionLineService productionTransactionLineService, IEventBus eventBus)
		{
			_productionTransactionLineService = productionTransactionLineService;
			_eventBus = eventBus;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetAll()
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesAsync();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<ProductionTransactionLine>> GetById(int id)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLineByIdAsync(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByCurrentId(int id)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByCurrentIdAsync(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByCurrentCode(string code)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByCurrentCodeAsync(code);
			return result;
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByProductId(int id)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByProductIdAsync(id);
			return result;
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByProductCode(string code)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByProductCodeAsync(code);
			return result;
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByFicheId(int id)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByFicheIdAsync(id);
			return result;
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByFicheCode(string code)
		{
			var result = await _productionTransactionLineService.GetProductionTransactionLinesByFicheCodeAsync(code);
			return result;
		}

		[HttpPost]
		public async Task InsertProductionTransactionLine([FromBody] ProductionTransactionLineDto productionTransactionLineDto)
		{
			_eventBus.Publish(new ProductionTransactionLineInsertedIntegrationEvent(productReferenceId: productionTransactionLineDto.productReferenceId,
				productCode: productionTransactionLineDto.productCode,
				quantity: productionTransactionLineDto.quantity,
				subUnitsetReferenceId: productionTransactionLineDto.subUnitsetReferenceId,
				subUnitsetCode: productionTransactionLineDto.subUnitsetCode,
				transactionDate: productionTransactionLineDto.transactionDate,
				transactionType: productionTransactionLineDto.transactionType,
				transactionTypeName: productionTransactionLineDto.transactionTypeName,
				referenceId: productionTransactionLineDto.referenceId,
				transactionTime: productionTransactionLineDto.transactionTime,
				convertedTime: productionTransactionLineDto.convertedTime,
				iOType: productionTransactionLineDto.iOType,
				warehouseNumber: productionTransactionLineDto.warehouseNumber,
				unitPrice: productionTransactionLineDto.unitPrice,
				vatRate: productionTransactionLineDto.vatRate,
				orderReferenceId: productionTransactionLineDto.orderReferenceId,
				description: productionTransactionLineDto.description,
				dispatchReferenceId: productionTransactionLineDto.dispatchReferenceId,
				speCode: productionTransactionLineDto.speCode,
				conversionFactor: productionTransactionLineDto.conversionFactor,
				otherConversionFactor: productionTransactionLineDto.otherConversionFactor,
				seriLotTransactions: productionTransactionLineDto.seriLotTransactions
				));
		}
	}
}
