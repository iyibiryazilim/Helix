using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseReturnDispatchTransactionQuery;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PurchaseReturnDispatchTransactionController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;
		public PurchaseReturnDispatchTransactionController(IConfiguration configuration, IPurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService)
		{
			_configuration = configuration;
			_purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
		}
		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetAll([FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionList(search, PurchaseReturnDispatchTransactionOrderBy.CodeDesc, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionList(search, PurchaseReturnDispatchTransactionOrderBy.CodeAsc, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionList(search, PurchaseReturnDispatchTransactionOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionList(search, PurchaseReturnDispatchTransactionOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

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
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(search, PurchaseReturnDispatchTransactionOrderBy.CodeDesc, id, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(search, PurchaseReturnDispatchTransactionOrderBy.CodeAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(search, PurchaseReturnDispatchTransactionOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentId(search, PurchaseReturnDispatchTransactionOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(search, PurchaseReturnDispatchTransactionOrderBy.CodeDesc, code, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(search, PurchaseReturnDispatchTransactionOrderBy.CodeAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(search, PurchaseReturnDispatchTransactionOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionByCurrentCode(search, PurchaseReturnDispatchTransactionOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}
	}
}
