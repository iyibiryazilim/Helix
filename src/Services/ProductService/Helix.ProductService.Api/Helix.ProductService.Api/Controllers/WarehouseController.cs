using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using IWarehouseService = Helix.ProductService.Application.Repository.IWarehouseService;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;

        }
        [HttpGet]
        public async Task<DataResult<IEnumerable<Warehouse>>> GetWarehousesAsync()
        {

            var result = await _warehouseService.GetWarehouseList();
            return result;
        }
    }
   


}
