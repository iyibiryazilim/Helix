using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class ProductDataStore : BaseDataStore, IProductService
	{
		private readonly ILogger<ProductDataStore> _logger;
		public ProductDataStore(IConfiguration configuration, ILogger<ProductDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}
		public async Task<DataResult<Product>> GetProductByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductByCode(code));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<Product>> GetProductById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductById(id));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
				throw;
			}
		}

		 

		public async Task<DataResult<IEnumerable<Product>>> GetProductList(string search, string groupCode, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<Product>().GetObjectsAsync(new ProductQuery(_configuraiton).GetProductList(search,groupCode,orderBy,page,pageSize));
				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
				throw;

			}
		}
	}
}
