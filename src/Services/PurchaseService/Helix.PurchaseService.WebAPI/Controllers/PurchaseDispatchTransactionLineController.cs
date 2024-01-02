using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseDispatchTransactionLineQuery;

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
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetAll([FromQuery]string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineList(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
			 
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseDispatchTransactionLine>> GetById(int id)
		{
 			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery]string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc,id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentId(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
			 
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByCurrentCode(string code,[FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByCurrentCode(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
			 
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductId(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			} 
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByProductCode(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			} 
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, id, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, id, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheId(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			} 
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransactionLine>>();
			switch (orderBy)
			{
				case "fichecodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeDesc, code, page, pageSize);
					return result;
				case "fichecodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.FicheCodeAsc, code, page, pageSize);
					return result;
				case "productcodedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;
				case "productnamedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionLineByFicheCode(search, PurchaseDispatchTransactionLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
			 
		}
	}
}
