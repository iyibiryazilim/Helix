using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace Helix.ProductService.Infrastructure.Repository
{
    public class CommercialProductDataStore : BaseDataStore, ICommercialProductService
	{
		private readonly ILogger<CommercialProductDataStore> _logger;

		public CommercialProductDataStore(IConfiguration configuration,ILogger<CommercialProductDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<CommercialProduct>> GetProductByCode(string code)
		{
			try
			{
				
                var result = await new SqlQueryHelper<CommercialProduct>().GetObjectAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductByCode(code));
                _logger.LogInformation("Ürün kodu {ProductCode} ile başarıyla getirildi. Mesaj: {ResultMessage}", code, result.Message);

                
                return result;
            }
			catch (Exception ex) {
			
				_logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
				throw;
			
			}	
		}

		public async Task<DataResult<CommercialProduct>> GetProductById(int id)
		{
			try
			{
                var result = await new SqlQueryHelper<CommercialProduct>().GetObjectAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductById(id));
                return result;

            }
			catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

		public async Task<DataResult<IEnumerable<CommercialProduct>>> GetProductList()
		{
			try
			{
                var result = await new SqlQueryHelper<CommercialProduct>().GetObjectsAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductList());
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
