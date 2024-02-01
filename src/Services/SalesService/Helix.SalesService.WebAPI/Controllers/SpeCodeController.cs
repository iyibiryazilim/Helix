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
    public class SpeCodeController : ControllerBase
    {
        ISpeCodeModelService _speCodeService;
        public SpeCodeController(ISpeCodeModelService speCodeService)
        {
            _speCodeService= speCodeService;
        }
        [HttpGet()]
        public async Task<DataResult<IEnumerable<SpeCodeModel>>> GetSpeCodeListAsync()
        {
            var result = await _speCodeService.GetSpeCodeListAsync();
            return result;
        }

    }
}
