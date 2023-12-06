using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class RawProductDataStore : BaseDataStore, IRawProductService
	{
		public RawProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<RawProduct>> GetProductByCode(string code)
		{

			var result = new SqlQueryHelper<RawProduct>().GetObjectAsync(new RawProductQuery(_configuraiton).GetRawProductByCode(code));
			return result;
		}

		public Task<DataResult<RawProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<RawProduct>().GetObjectAsync(new RawProductQuery(_configuraiton).GetRawProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<RawProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<RawProduct>().GetObjectsAsync(new RawProductQuery(_configuraiton).GetRawProductList());
			return result;
		}
	}
}
