using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class RawProductDataStore : BaseDataStore, IRawProductService
	{
		private readonly ILogger<RawProductDataStore> _logger;	

		public RawProductDataStore(IConfiguration configuration, ILogger<RawProductDataStore> logger) : base(configuration)
		{
            _logger = logger;

        }

		public async Task<DataResult<RawProduct>> GetProductByCode(string code)
		{
			try
			{
                var result = await new SqlQueryHelper<RawProduct>().GetObjectAsync(new RawProductQuery(_configuraiton).GetRawProductByCode(code));
                return result;

            }
			catch(Exception ex)
			{
				_logger.LogWarning(ex.Message,DateTime.UtcNow.ToLongTimeString());
				throw;
			}
			
		}

		public async Task<DataResult<RawProduct>> GetProductById(int id)
		{
			try
			{
                var result = await new SqlQueryHelper<RawProduct>().GetObjectAsync(new RawProductQuery(_configuraiton).GetRawProductById(id));
                return result;

            }
			catch(Exception ex) {
				_logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<RawProduct>>> GetProductList()
		{
			try
			{
                var result = await new SqlQueryHelper<RawProduct>().GetObjectsAsync(new RawProductQuery(_configuraiton).GetRawProductList());
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
