using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class SemiProductDataStore : BaseDataStore, ISemiProductService
	{
		public SemiProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<SemiProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductByCode(code));
			return result;
		}

		public Task<DataResult<SemiProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<SemiProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectsAsync(new SemiProductQuery(_configuraiton).GetSemiProductList());
			return result;
		}
	}
}
