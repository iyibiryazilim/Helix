using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseDispatchTransactionController : ControllerBase
	{
		private readonly ILogger<PurchaseDispatchTransactionController> _logger;
		IConfiguration _configuration;
		IPurchaseDispatchTransactionService _purchaseDispatchTransactionService;
		public PurchaseDispatchTransactionController(IConfiguration configuration, IPurchaseDispatchTransactionService purchaseDispatchTransactionService, ILogger<PurchaseDispatchTransactionController> logger)
		{
			_configuration = configuration;
			_purchaseDispatchTransactionService = purchaseDispatchTransactionService;
			_logger = logger;
		}
		//[HttpPost]
		//public async Task<DataResult<PurchaseDispatchTransaction>> Insert([FromBody] PurchaseDispatchTransactionInsertDto dto)
		//{
		//	var result = await _purchaseDispatchTransactionService.Insert(dto);
		//	return result;
		//}
		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetAll()
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseDispatchTransaction>> GetById(int id)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<PurchaseDispatchTransaction>> GetByCode(string code)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentId(int id)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentCode(string code)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(code);
			return result;
		}
	}
}
