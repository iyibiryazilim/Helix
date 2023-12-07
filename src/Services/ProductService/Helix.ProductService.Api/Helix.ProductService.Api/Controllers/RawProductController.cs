
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawProductController : ControllerBase
    {
        IRawProductService _rawProductService;
        
        public RawProductController(IRawProductService rawProductService)
        {
            _rawProductService = rawProductService;
            
        }

        [HttpGet]
        public async Task<DataResult<IEnumerable<RawProduct>>> GetAll()
        {
          
            var result = await _rawProductService.GetProductList();
            return result;
        }
        [HttpGet("Code/{code}")]
        public async Task<DataResult<RawProduct>> GetByCode(string code)
        {
            
            var result = await _rawProductService.GetProductByCode(code);
            return result;
        }
        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<RawProduct>> GetById(int id)
        {
           
            var result = await _rawProductService.GetProductById(id);
            return result;
        }

    }
}
