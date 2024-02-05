using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IWarehouseService = Helix.ProductService.Application.Repository.IWarehouseService;

namespace Helix.ProductService.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class WarehouseController : ControllerBase
    {
        IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;

        }
        [HttpGet]
        public async Task<DataResult<IEnumerable<Warehouse>>> GetWarehousesAsync([FromQuery] string search = "", string orderBy = WarehouseOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
        {
			DataResult<IEnumerable<Warehouse>> result = new();
			switch (orderBy)
			{
				case "namedesc":
					result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNameDesc, page, pageSize);
					return result;
				case "nameasc":
					result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNameAsc, page, pageSize);
					return result;
				case "numberdesc":
					result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNumberDesc, page, pageSize);
					return result;
				case "numberasc":
					result = await _warehouseService.GetWarehouseList(search, WarehouseOrderBy.ItemNumberAsc, page, pageSize);
					return result;
				default:
					result = await _warehouseService.GetWarehouseList(search, orderBy, page, pageSize);
					return result;
			}

        }
    }
   


}
