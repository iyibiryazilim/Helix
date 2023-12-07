using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseReturnDispatchTransactionLineController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseReturnDispatchTransactionLineService _purchaseReturnDispatchTransactionService;
		public PurchaseReturnDispatchTransactionLineController(IConfiguration configuration, IPurchaseReturnDispatchTransactionLineService purchaseReturnDispatchTransactionService)
		{
			_configuration = configuration;
			_purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
		}


		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetAll()
		{
			var result = await _purchaseReturnDispatchTransactionService.GetTransactionList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetById(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionById(id);
			return result;
		}

		 

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByCurrentId(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByCurrentCode(string code)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(code);
			return result;
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByProductId(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByProductId(id);
			return result;
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByProductCode(string code)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByProductCode(code);
			return result;
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheId(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByFicheId(id);
			return result;
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheCode(string code)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByFicheCode(code);
			return result;
		}
	}
}
