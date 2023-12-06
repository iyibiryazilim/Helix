using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class SupplierDataStore : BaseDataStore, ISupplierService
	{
		public SupplierDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<Supplier>> GetSupplierByCode(string code)
		{
			var result = new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierByCode(code));
			return result;
		}

		public Task<DataResult<Supplier>> GetSupplierById(int id)
		{
			var result = new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<Supplier>>> GetSupplierList()
		{
			var result = new SqlQueryHelper<Supplier>().GetObjectsAsync(new SupplierQuery(_configuraiton).GetSupplierList());
			return result;
		}
	}
}
