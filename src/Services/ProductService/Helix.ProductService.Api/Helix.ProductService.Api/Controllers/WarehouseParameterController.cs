using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class WarehouseParameterController : ControllerBase
    {
        IWarehouseParameterService _warehouseParameterService;
        public WarehouseParameterController(IWarehouseParameterService warehouseParameterService)
        {
            _warehouseParameterService = warehouseParameterService;
            
        }

        [HttpGet("Warehouse/Id/{id}")]
        public async Task<DataResult<IEnumerable<WarehouseParameter>>> GetWarehouseParameterByProductId(int id, [FromQuery] string search = "", string orderBy = WarehouseParameterOrderBy.WarehouseNameDesc, int page = 0, int pageSize = 20)
        {
            DataResult<IEnumerable<WarehouseParameter>> result = new();
            switch (orderBy)
            {
                case "warehousenamedesc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.WarehouseNameDesc, page, pageSize);
                    return result;
                case "warehousenameasc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.WarehouseNameAsc, page, pageSize);
                    return result;
                case "warehousenumberdesc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.WarehouseNumberDesc, page, pageSize);
                    return result;
                case "warehousenumberasc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.WarehouseNumberAsc, page, pageSize);
                    return result;
                case "quantityasc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.QuantityAsc, page, pageSize);
                    return result;
                case "quantitydesc":
                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, WarehouseParameterOrderBy.QuantityDesc, page, pageSize);
                    return result;
                default:

                    result = await _warehouseParameterService.GetWarehouseParameterByProductId(id, search, orderBy, page, pageSize);
                    return result;

            }

        }



    }
}
