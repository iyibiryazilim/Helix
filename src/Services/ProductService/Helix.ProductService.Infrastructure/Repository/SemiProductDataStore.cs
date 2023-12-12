
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class SemiProductDataStore : BaseDataStore, ISemiProductService
	{
		private readonly ILogger _logger;
		public SemiProductDataStore(IConfiguration configuration, ILogger<SemiProductDataStore>logger) : base(configuration)
		{
			_logger = logger;
		}

		public async  Task<DataResult<SemiProduct>> GetProductByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductByCode(code));
			return result;
			}
			catch (Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }

		}

		public async Task<DataResult<SemiProduct>> GetProductById(int id)
		{
			try
			{
                var result = await new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductById(id));
                return result;

            }
			catch (Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }

        }

		public async  Task<DataResult<IEnumerable<SemiProduct>>> GetProductList()
		{
			try
			{
                var result = await new SqlQueryHelper<SemiProduct>().GetObjectsAsync(new SemiProductQuery(_configuraiton).GetSemiProductList());
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
