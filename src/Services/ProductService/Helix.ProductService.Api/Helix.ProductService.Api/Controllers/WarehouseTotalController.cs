using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WarehouseTotalController : ControllerBase
	{
		IWarehouseTotalService _warehouseTotalService;
		public WarehouseTotalController(IWarehouseTotalService warehouseTotalService)
		{
			_warehouseTotalService = warehouseTotalService;

		}

		[HttpGet("Warehouse/Number/{number}&{cardType}")]
		public async Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehousesAsync(int number, string cardType = "1,2,3,4,10,11,12,13", [FromQuery] string search = "", string orderBy = WarehouseTotalOrderBy.CodeAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<WarehouseTotal>> result = new();
			switch (orderBy)
			{
				case "namedesc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number,cardType,search, WarehouseTotalOrderBy.NameDesc, page, pageSize);
					return result;
				case "nameasc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search, WarehouseTotalOrderBy.NameAsc, page, pageSize);
					return result;
				case "codedesc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search, WarehouseTotalOrderBy.CodeDesc, page, pageSize);
					return result;
				case "codeasc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search, WarehouseTotalOrderBy.CodeAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search, WarehouseTotalOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search, WarehouseTotalOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _warehouseTotalService.GetProductsByWarehouseNumber(number, cardType, search,orderBy, page, pageSize);
					return result;
			}

		}
	}
}
