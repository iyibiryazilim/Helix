using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseDispatchTransactionLineController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseDispatchTransactionLineService _purchaseDispatchTransactionService;
		public PurchaseDispatchTransactionLineController(IConfiguration configuration, IPurchaseDispatchTransactionLineService purchaseDispatchTransactionService)
		{
			_configuration = configuration;
			_purchaseDispatchTransactionService = purchaseDispatchTransactionService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetAll()
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseDispatchTransactionLine>> GetById(int id)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByCurrentId(int id)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByCurrentCode(string code)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(code);
			return result;
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByProductId(int id)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(id);
			return result;
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByProductCode(string code)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(code);
			return result;
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByFicheId(int id)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(id);
			return result;
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByFicheCode(string code)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(code);
			return result;
		}
	}
}
