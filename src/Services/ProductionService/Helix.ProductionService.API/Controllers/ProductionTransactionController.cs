using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductionTransactionController : ControllerBase
	{
		IProductionTransactionService _productionTransactionService;
		public ProductionTransactionController(IProductionTransactionService productionTransactionService)
		{
			_productionTransactionService = productionTransactionService;
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
	}
}
