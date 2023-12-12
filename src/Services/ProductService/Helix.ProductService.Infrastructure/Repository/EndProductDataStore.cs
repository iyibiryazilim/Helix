
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class EndProductDataStore : BaseDataStore, IEndProductService
	{
		private readonly ILogger<EndProductDataStore> _logger;
		public EndProductDataStore(IConfiguration configuration,ILogger<EndProductDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<EndProduct>> GetProductByCode(string code)
		{
			try
			{
                var result = await new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductByCode(code));
                return result;
            }
			catch(Exception ex) {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
		}

		public async Task<DataResult<EndProduct>> GetProductById(int id)
		{
			try
			{
                var result = await new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductById(id));
                return result;
            }
			catch(Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
		}

		public async Task<DataResult<IEnumerable<EndProduct>>> GetProductList()
		{
			try
			{
                var result = await new SqlQueryHelper<EndProduct>().GetObjectsAsync(new EndProductQuery(_configuraiton).GetEndProductList());
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
