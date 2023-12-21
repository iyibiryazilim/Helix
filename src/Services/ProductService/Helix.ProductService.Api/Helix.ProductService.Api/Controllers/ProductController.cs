
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<Product>>> GetAll([FromQuery] string search = "", string groupCode = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<Product>> result = new();
			switch (orderBy)
			{
				case "namedesc":
					result = await _productService.GetProductList(search, groupCode, ProductOrderBy.ItemNameDesc, page, pageSize);
					return result;
				case "nameasc":
					result = await _productService.GetProductList(search, groupCode, ProductOrderBy.ItemNameAsc, page, pageSize);
					return result;
				case "codedesc":
					result = await _productService.GetProductList(search, groupCode, ProductOrderBy.ItemCodeDesc, page, pageSize);
					return result;
				case "codeasc":
					result = await _productService.GetProductList(search, groupCode, ProductOrderBy.ItemCodeAsc, page, pageSize);
					return result;
				default:
					result = await _productService.GetProductList(search, groupCode, orderBy, page, pageSize);
					return result;
			}


		}
		[HttpGet("Code/{code}")]
		public async Task<DataResult<Product>> GetByCode(string code)
		{

			var result = await _productService.GetProductByCode(code);
			return result;
		}
		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<Product>> GetById(int id)
		{

			var result = await _productService.GetProductById(id);
			return result;
		}

		[HttpGet($"{nameof(ProductGroup)}")]
		public async Task<DataResult<IEnumerable<ProductGroup>>> GetProductCodes()
		{

			var result = await _productService.GetProductGroupCodes();
			return result;
		}
	}
}
