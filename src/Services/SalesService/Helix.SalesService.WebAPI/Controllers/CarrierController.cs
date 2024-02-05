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
	public class CarrierController : ControllerBase
    {
        ICarrierService _carrierService;

        public CarrierController( ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet()]
        public async Task<DataResult<IEnumerable<Carrier>>>GetCarrierListAsync()
        {
            var result= await _carrierService.GetCarriersListAsync();
            return result;
        }
    }
}
