
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class FixedAssetProductDataStore : BaseDataStore, IFixedAssetProductService
	{
		public FixedAssetProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<FixedAssetProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<FixedAssetProduct>().GetObjectAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductByCode(code));
			return result;
		}

		public Task<DataResult<FixedAssetProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<FixedAssetProduct>().GetObjectAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<FixedAssetProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<FixedAssetProduct>().GetObjectsAsync(new FixedAssetProductQuery(_configuraiton).GetFixedAssetProductList());
			return result;
		}
	}
}
