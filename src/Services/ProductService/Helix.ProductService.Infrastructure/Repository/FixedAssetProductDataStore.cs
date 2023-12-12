
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class FixedAssetProductDataStore : BaseDataStore, IFixedAssetProductService
	{
		private readonly ILogger<FixedAssetProductDataStore> _logger;

		public FixedAssetProductDataStore(IConfiguration configuration, ILogger<FixedAssetProductDataStore> logger) : base(configuration)
		{
			_logger = logger;

        }

		public async Task<DataResult<FixedAssetProduct>> GetProductByCode(string code)
		{
			try
			{
                var result = await new SqlQueryHelper<FixedAssetProduct>().GetObjectAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductByCode(code));
                return result;
            }
			catch(Exception ex) 
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }

		}

		public async Task<DataResult<FixedAssetProduct>> GetProductById(int id)
		{
			try
			{
                var result = await new SqlQueryHelper<FixedAssetProduct>().GetObjectAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductById(id));
                return result;

            }
			catch (Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;

            }
			
		}

		public async Task<DataResult<IEnumerable<FixedAssetProduct>>> GetProductList()
		{
			try
			{
                var result =await new SqlQueryHelper<FixedAssetProduct>().GetObjectsAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductList());
                return result;

            }
			catch(Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
			
		}
	}
}
