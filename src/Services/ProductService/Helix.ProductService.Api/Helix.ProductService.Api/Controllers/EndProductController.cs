using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class EndProductController : ControllerBase
    {
        IEndProductService _endProductService;
       
        public EndProductController(IEndProductService endProductService)
        {
            _endProductService = endProductService;
           
        }

        [HttpGet]
        public async Task<DataResult<IEnumerable<EndProduct>>> GetAll()
        {
            
            var result = await _endProductService.GetProductList();
            return result;
        }
        [HttpGet("Code/{code}")]
        public async Task<DataResult<EndProduct>> GetByCode(string code)
        {
            
            var result = await _endProductService.GetProductByCode(code);
            return result;
        }
        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<EndProduct>> GetById(int id)
        {
            
            var result = await _endProductService.GetProductById(id);
            return result;
        }
    }
}
