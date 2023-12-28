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
		//[HttpGet]
		//public async Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehousesAsync(int number,string cardType="", [FromQuery] string search = "", string orderBy = WarehouseTotalOrderBy.CodeAsc, int page = 0, int pageSize = 20)
		//{
		//	DataResult<IEnumerable<WarehouseTotal>> result = new();
		//	switch (orderBy)
		//	{
		//		case "namedesc":
		//			result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNameDesc, page, pageSize);
		//			return result;
		//		case "nameasc":
		//			result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNameAsc, page, pageSize);
		//			return result;
		//		case "numberdesc":
		//			result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNumberDesc, page, pageSize);
		//			return result;
		//		case "numberasc":
		//			result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNumberAsc, page, pageSize);
		//			return result;
		//		default:
		//			result = await _warehouseService.GetWarehouseList(search, orderBy, page, pageSize);
		//			return result;
		//	}

		//}
	}
}
