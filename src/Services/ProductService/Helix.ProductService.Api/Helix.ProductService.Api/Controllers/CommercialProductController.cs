using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialProductController : ControllerBase
    {
        ICommercialProductService _commercialProductService;

        public CommercialProductController(ICommercialProductService commercialProductService)
        {
            _commercialProductService= commercialProductService;
        }

        [HttpGet]
        public async Task<DataResult<IEnumerable<CommercialProduct>>> GetAll()
        {
            var result = await _commercialProductService.GetProductList();
            return result;
        }
        [HttpGet("Code/{code}")]
        public async Task<DataResult<CommercialProduct>> GetByCode(string code)
        {
            var result = await _commercialProductService.GetProductByCode(code);
            return result;
        }
        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<CommercialProduct>> GetById(int id)
        {
            var result = await _commercialProductService.GetProductById(id);
            return result;
        }



    }
}
