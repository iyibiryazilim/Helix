using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProductionOrderController : ControllerBase
	{
		IProductionOrderService _productionOrderService;

		public ProductionOrderController(IProductionOrderService productionOrderService)
		{
			_productionOrderService = productionOrderService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<ProductionOrder>>> GetAll()
		{
			var result = await _productionOrderService.GetProductionOrderList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<ProductionOrder>> GetById(int id)
		{
			var result = await _productionOrderService.GetProductionOrderById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<ProductionOrder>> GetByCode(string code)
		{
			var result = await _productionOrderService.GetProductionOrderByCode(code);
			return result;
		}
	}
}
