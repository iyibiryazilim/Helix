using Consul;
using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
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

		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetAll([FromQuery] bool includeWaiting = false, string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductCodeDesc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductCodeAsc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductNameDesc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductNameAsc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentNameDesc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentNameDesc, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentNameAsc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.CurrentNameAsc, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.DateAsc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLine(search, PurchaseOrderLineOrderBy.DateDesc, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLine(search, PurchaseOrderLineOrderBy.DateDesc, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}
		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCode(string code, [FromQuery] bool includeWaiting = false,string search = "",string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc,code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;

				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByFicheId(int id, [FromQuery] bool includeWaiting = false, string search = "",string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{

				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;

				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByFicheId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCurrentId(int id, [FromQuery] bool includeWaiting = false, string search = "",string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		 
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByCurrentCode(string code, [FromQuery] bool includeWaiting = false, string search = "",string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByCurrentCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		 
		}

		[HttpGet("Product/Id/{id}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByProductId(int id, [FromQuery] bool includeWaiting = false, string search = "",string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductCodeDesc, id, page, pageSize);
					return result;
				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductCodeAsc, id, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductNameDesc, id, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.ProductNameAsc, id, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, id, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, id, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentNameDesc, id, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.CurrentNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductId(search, PurchaseOrderLineOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpGet("Product/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetByProductCode(string code, [FromQuery] bool includeWaiting = false, string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrderLine>>();
			switch (orderBy)
			{
				case "productcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductCodeDesc, code, page, pageSize);
					return result;
				case "productcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductCodeAsc, code, page, pageSize);
					return result;

				case "productnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductNameDesc, code, page, pageSize);
					return result;
				case "productnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.ProductNameAsc, code, page, pageSize);
					return result;
				case "currentcodedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentCodeDesc, code, page, pageSize);
					return result;
				case "currentcodeasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentCodeAsc, code, page, pageSize);
					return result;
				case "currentnamedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentNameDesc, code, page, pageSize);
					return result;
				case "currentnameasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.CurrentNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					if (includeWaiting)
					{
						result = await _purchaseOrderLineService.GetWaitingPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
						return result;
					}
					result = await _purchaseOrderLineService.GetPurchaseOrderLineByProductCode(search, PurchaseOrderLineOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}
	}
}
