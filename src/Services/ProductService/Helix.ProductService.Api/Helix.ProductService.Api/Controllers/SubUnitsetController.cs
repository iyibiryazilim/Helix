using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.Tiger.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class SubUnitsetController : ControllerBase
    {
        //ISubUnitsetService _subUnitsetService;
        //public SubUnitsetController(ISubUnitsetService subUnitsetService)
        //{
        //    _subUnitsetService=subUnitsetService;
        //}

        //[HttpGet]
        //public async Task<DataResult<IEnumerable<SubUnitset>>> GetAll()
        //{
        //    var result= await _subUnitsetService.GetSubUnitsetList();
        //    return result;
        //}

        //[HttpGet("Unitset/Id/{id:int}")]
        //public async Task<DataResult<IEnumerable<SubUnitset>>> GetByUnitsetId(int id)
        //{
        //    var result = await _subUnitsetService.GetSubUnitsetByUnitsetId(id);
        //    return result;
        //}

        //[HttpGet("Product/Id/{id:int}")]
        //public async Task<DataResult<IEnumerable<SubUnitset>>> GetByProductId(int id)
        //{
        //    var result = await _subUnitsetService.GetSubUnitsetsFromProductId(id);
        //    return result;
        //}

        //[HttpGet("Id/{id:int}")]
        //public async Task<DataResult<IEnumerable<SubUnitset>>> GetById(int id)
        //{
        //    var result = await _subUnitsetService.GetSubUnitsetById(id);
        //    return result;
        //}




    }
}
