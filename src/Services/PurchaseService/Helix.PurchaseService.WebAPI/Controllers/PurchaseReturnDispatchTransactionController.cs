using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseReturnDispatchTransactionController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;
		public PurchaseReturnDispatchTransactionController(IConfiguration configuration, IPurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService)
		{
			_configuration = configuration;
			_purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
		}
		//[HttpPost]
		//public async Task<DataResult<PurchaseReturnDispatchTransaction>> Insert([FromBody] PurchaseReturnDispatchTransactionInsertDto dto)
		//{
		//	var result = await _purchaseReturnDispatchTransactionService.Insert(dto);
		//	return result;
		//}
		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetAll()
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetById(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetByCode(string code)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetByCurrentId(int id)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetByCurrentCode(string code)
		{
 			var result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(code);
			return result;
		}
	}
}
