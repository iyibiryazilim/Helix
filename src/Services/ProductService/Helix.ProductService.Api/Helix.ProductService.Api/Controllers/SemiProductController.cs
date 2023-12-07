
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemiProductController : ControllerBase
    {
        ISemiProductService _semiProductService;
	
	public SemiProductController(ISemiProductService semiProductService)
	{
		_semiProductService = semiProductService;
		
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<SemiProduct>>> GetAll()
	{
		
		var result = await _semiProductService.GetProductList();
		return result;
	}
	[HttpGet("Code/{code}")]
	public async Task<DataResult<SemiProduct>> GetByCode(string code)
	{
		
		var result = await _semiProductService.GetProductByCode(code);
		return result;
	}
	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<SemiProduct>> GetById(int id)
	{
		
		var result = await _semiProductService.GetProductById(id);
		return result;
	}

    }
}
