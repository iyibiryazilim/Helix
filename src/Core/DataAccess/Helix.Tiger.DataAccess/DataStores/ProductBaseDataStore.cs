using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class ProductBaseDataStore : BaseDataStore, IProductService
	{
		public ProductBaseDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<Product>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductByCode(code));
			return result;
		}

		public Task<DataResult<Product>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<Product>>> GetProductList()
		{
			var result = new SqlQueryHelper<Product>().GetObjectsAsync(new ProductQuery(_configuraiton).GetProductList());
			return result;
		}
	}
}
