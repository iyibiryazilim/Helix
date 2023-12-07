using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseOrderController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseOrderService _purchaseOrderService;
		public PurchaseOrderController(IConfiguration configuration, IPurchaseOrderService purchaseOrderService)
		{
			_configuration = configuration;
			_purchaseOrderService = purchaseOrderService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetAll()
		{
 			var result = await _purchaseOrderService.GetPurchaseOrderList();
			return result;
		}
		[HttpGet("Code/{code}")]
		public async Task<DataResult<PurchaseOrder>> GetByCode(string code)
		{
 			var result = await _purchaseOrderService.GetPurchaseOrderByCode(code);
			return result;
		}
		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseOrder>> GetById(int id)
		{
			var result = await _purchaseOrderService.GetPurchaseOrderById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetByCurrentId(int id)
		{
 			var result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetByCurrentCode(string code)
		{
 			var result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(code);
			return result;
		}
	}
}
