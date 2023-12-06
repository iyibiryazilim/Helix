using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class CommercialProductDataStore : BaseDataStore, ICommercialProductService
	{
		public CommercialProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<CommercialProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<CommercialProduct>().GetObjectAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductByCode(code));
			return result;
		}

		public Task<DataResult<CommercialProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<CommercialProduct>().GetObjectAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<CommercialProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<CommercialProduct>().GetObjectsAsync(new CommercialProductQuery(_configuraiton).GetCommercialProductList());
			return result;
		}
	}
}
