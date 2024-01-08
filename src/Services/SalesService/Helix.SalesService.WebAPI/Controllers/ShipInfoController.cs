using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipInfoController : ControllerBase
    {
        IShipInfoService _shipInfoService;
        public ShipInfoController(IShipInfoService shipInfoService)
        {
            _shipInfoService = shipInfoService; 
            
        }

        
        [HttpGet("Current/Id/{currentReferenceId}")]
        public async Task<DataResult<IEnumerable<ShipInfo>>> GetShipInfoListAsync(int currentReferenceId)
        {
            var result = await _shipInfoService.GetShipInfoListAsync(currentReferenceId);
            return result;
        }
    }
}
