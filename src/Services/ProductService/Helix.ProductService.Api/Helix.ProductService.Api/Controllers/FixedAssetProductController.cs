
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class FixedAssetProductController : ControllerBase
    {
        IFixedAssetProductService _fixedAssetProductService;
       
        public FixedAssetProductController(IFixedAssetProductService fixedAssetProductService)
        {
            _fixedAssetProductService = fixedAssetProductService;
            
        }

       [HttpGet("Code/{code}")]
        public async Task<DataResult<FixedAssetProduct>> GetByCode(string code)
        {
           
            var result = await _fixedAssetProductService.GetProductByCode(code);
            return result;
        }
        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<FixedAssetProduct>> GetById(int id)
        {
            var result = await _fixedAssetProductService.GetProductById(id);
            return result;
        }
        [HttpGet]
        public async Task<DataResult<IEnumerable<FixedAssetProduct>>> GetAll()
        {

            var result = await _fixedAssetProductService.GetProductList();
            return result;
        }
    }
}
