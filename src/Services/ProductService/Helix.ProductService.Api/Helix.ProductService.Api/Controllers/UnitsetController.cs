using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.Tiger.DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsetController : ControllerBase
    {
        IUnitsetService _unitsetService;
        public UnitsetController(IUnitsetService unitsetService)
        {
            _unitsetService = unitsetService;
        }


        [HttpGet]
        public async Task<DataResult<IEnumerable<Unitset>>> GetAll()
        {

            var result = await _unitsetService.GetUnitsetList();
            return result;
        }

        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<IEnumerable<Unitset>>> GetById(int id)
        {

            var result = await _unitsetService.GetUnitsetById(id);
            return result;
        }

        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<IEnumerable<Unitset>>> GetByProductId(int id)
        {

            var result = await _unitsetService.GetUnitsetFromProductId(id);
            return result;
        }
    }
}
