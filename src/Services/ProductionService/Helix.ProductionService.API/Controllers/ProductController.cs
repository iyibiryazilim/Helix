using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Domain.Models.BaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProductController : ControllerBase
	{
		IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<Product>>> GetAll()
		{
			var result = await _productService.GetProductList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<Product>> GetById(int id)
		{
			var result = await _productService.GetProductById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<Product>> GetByCode(string code)
		{
			var result = await _productService.GetProductByCode(code);
			return result;
		}
	}
}
