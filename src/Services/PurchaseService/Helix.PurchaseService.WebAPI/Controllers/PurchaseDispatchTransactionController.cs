using Consul;
using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseDispatchTransactionQuery;

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
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetAll([FromQuery]string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.CodeDesc , page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.CodeAsc , page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
			 
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
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.CodeDesc, id, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.CodeAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		 
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc , int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{ 
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.CodeDesc, code, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.CodeAsc, code,page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.DateAsc, code ,page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			} 
		}
	}
}
