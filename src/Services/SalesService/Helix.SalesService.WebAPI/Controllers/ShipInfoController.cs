using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
