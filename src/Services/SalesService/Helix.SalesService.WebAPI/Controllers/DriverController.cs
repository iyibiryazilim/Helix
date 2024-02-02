using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class DriverController : ControllerBase
    {
        IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet()]
        public async Task<DataResult<IEnumerable<Driver>>> GetDriverListAsync()
        {
            
            var result = await _driverService.GetDriversListAsync();
            return result;
        }
    }
}
