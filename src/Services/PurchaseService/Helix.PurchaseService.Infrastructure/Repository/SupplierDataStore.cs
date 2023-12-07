using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.PurchaseService.Infrastructure.Repository
{
	public class SupplierDataStore : BaseDataStore, ISupplierService
	{
		public SupplierDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<Supplier>> GetSupplierByCode(string code)
		{
			var result = await new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierByCode(code));
			return result;
		}

		public async Task<DataResult<Supplier>> GetSupplierById(int id)
		{
			var result = await new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<Supplier>>> GetSupplierList()
		{
			var result = await new SqlQueryHelper<Supplier>().GetObjectsAsync(new SupplierQuery(_configuraiton).GetSupplierList());
			return result;
		}
	}
}
