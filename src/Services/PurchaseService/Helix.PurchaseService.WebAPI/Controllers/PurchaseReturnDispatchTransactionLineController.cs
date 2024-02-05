using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseReturnDispatchTransactionLineQuery;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
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
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetAll([FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineList(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetById(int id)
		{
			var result = await _purchaseReturnDispatchTransactionService.GetTransactionLineById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByCurrentCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByProductCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheId(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseReturnDispatchTransactionService.GetTransactionLineByFicheCode(search, PurchaseReturnDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}
	}
}
