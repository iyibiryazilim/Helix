using Consul;
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Helix.ProductService.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class ProductTransactionLineController : ControllerBase
	{
		IProductTransactionLineService _productTransactionLineService;
        public ProductTransactionLineController(IProductTransactionLineService productTransactionLineService)
        {
            _productTransactionLineService = productTransactionLineService;
        }

		[HttpGet("Product/Id/{ProductId:int}")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductIdAsync(int ProductId, [FromQuery] string search = "", string orderBy = ProductTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetTransactionLinesByProductIdAsync(ProductId, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetTransactionLinesByProductIdAsync(ProductId, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetTransactionLinesByProductIdAsync(ProductId, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetTransactionLinesByProductIdAsync(ProductId, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetTransactionLinesByProductIdAsync(ProductId, search, orderBy, page, pageSize);
					return result;
			}
		}
		[HttpGet("Product/Code/{ProductCode}")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductCodeAsync(string ProductCode, [FromQuery] string search = "", string orderBy = ProductTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetTransactionLinesByProductCodeAsync(ProductCode, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetTransactionLinesByProductCodeAsync(ProductCode, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetTransactionLinesByProductCodeAsync(ProductCode, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetTransactionLinesByProductCodeAsync(ProductCode, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetTransactionLinesByProductCodeAsync(ProductCode, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("ProductAndTransactionType/{ProductCode}&{TransactionType}")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionType(string ProductCode, string TransactionType, [FromQuery] string search = "", string orderBy = ProductTransactionLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetTransactionLineByTransactionTypeAsync(ProductCode,TransactionType, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetTransactionLineByTransactionTypeAsync(ProductCode, TransactionType, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetTransactionLineByTransactionTypeAsync(ProductCode, TransactionType, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetTransactionLineByTransactionTypeAsync(ProductCode, TransactionType, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetTransactionLineByTransactionTypeAsync(ProductCode, TransactionType, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Product/Id/{id:int}/Input")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductId(int id, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetInputTransactionLineByProductId(id, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Product/Code/{code}/Input")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductCode(string code, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetInputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetInputTransactionLineByProductCode(code, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Product/Id/{id:int}/Output")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductId(int id, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductId(id, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetOutputTransactionLineByProductId(id, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Product/Code/{code}/Output")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductCode(string code, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetOutputTransactionLineByProductCode(code, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetOutputTransactionLineByProductCode(code, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Fiche/Code/{code}")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheCode(string code, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetTransactionLineByFicheCode(code, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetTransactionLineByFicheCode(code, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetTransactionLineByFicheCode(code, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetTransactionLineByFicheCode(code, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetTransactionLineByFicheCode(code, search, orderBy, page, pageSize);
					return result;
			}
		}

		[HttpGet("Fiche/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheId(int id, [FromQuery] string search = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
		{
			DataResult<IEnumerable<ProductTransactionLine>> result = new();

			switch (orderBy)
			{
				case "datedesc":
					result = await _productTransactionLineService.GetTransactionLineByFicheId(id, search, ProductTransactionLineOrderBy.DateDesc, page, pageSize);
					return result;
				case "dateasc":
					result = await _productTransactionLineService.GetTransactionLineByFicheId(id, search, ProductTransactionLineOrderBy.DateAsc, page, pageSize);
					return result;
				case "quantitydesc":
					result = await _productTransactionLineService.GetTransactionLineByFicheId(id, search, ProductTransactionLineOrderBy.QuantityDesc, page, pageSize);
					return result;
				case "quantityasc":
					result = await _productTransactionLineService.GetTransactionLineByFicheId(id, search, ProductTransactionLineOrderBy.QuantityAsc, page, pageSize);
					return result;
				default:
					result = await _productTransactionLineService.GetTransactionLineByFicheId(id, search, orderBy, page, pageSize);
					return result;
			}
		}
	}
}
