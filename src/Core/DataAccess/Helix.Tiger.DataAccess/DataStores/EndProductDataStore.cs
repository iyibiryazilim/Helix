using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class EndProductDataStore : BaseDataStore, IEndProductService
	{
		public EndProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<EndProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductByCode(code));
			return result;
		}

		public Task<DataResult<EndProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<EndProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectsAsync(new EndProductQuery(_configuraiton).GetEndProductList());
			return result;
		}
	}
}
