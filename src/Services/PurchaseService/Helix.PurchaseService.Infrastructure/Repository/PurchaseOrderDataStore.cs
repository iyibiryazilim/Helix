using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;


namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseOrderDataStore : BaseDataStore, IPurchaseOrderService
	{
		public PurchaseOrderDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderList()
		{
			var result = await  new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderQuery());
			return result;
		}

		public async Task<DataResult<PurchaseOrder>> GetPurchaseOrderByCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCodeQuery(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentCodeQuery(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentId(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentIdQuery(id));
			return result;
		}

		public async Task<DataResult<PurchaseOrder>> GetPurchaseOrderById(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByIdQuery(id));
			return result;
		}
	}
}
