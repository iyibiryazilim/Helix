using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseOrderLineController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseOrderLineService _purchaseOrderLineService;
		public PurchaseOrderLineController(IConfiguration configuration, IPurchaseOrderLineService purchaseOrderLineService)
		{
			_configuration = configuration;
			_purchaseOrderLineService = purchaseOrderLineService;
		}

		[HttpGet("{includeWaiting}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetAll(bool includeWaiting = false)
		{
			if (includeWaiting)
			{
 				var _result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine();
				return _result;
			}
 			var result = await _purchaseOrderLineService.GetPurchaseOrderLine();
			return result;
		}
		[HttpGet("Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCode(string code)
		{

 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineByCode(code);
			return result;
		}
		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseOrderLine>> GetById(int id)
		{
 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}&{includeWaiting}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCurrentId(int id, bool includeWaiting = false)
		{
			if (includeWaiting)
			{
				var _result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(id);
				return _result;
			}

 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}&{includeWaiting}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCurrentCode(string code, bool includeWaiting = false)
		{
			if (includeWaiting)
			{
 				var _result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(code);
				return _result;
			}

 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(code);
			return result;
		}

		[HttpGet("Product/Id/{id}&{includeWaiting}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByProductId(int id, bool includeWaiting = false)
		{
			if (includeWaiting)
			{
 				var _result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(id);
				return _result;
			}

 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(id);
			return result;
		}

		[HttpGet("Product/Code/{code}&{includeWaiting}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByProductCode(string code, bool includeWaiting = false)
		{
			if (includeWaiting)
			{
 				var _result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(code);
				return _result;
			}

 			var result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(code);
			return result;
		}
	}
}
