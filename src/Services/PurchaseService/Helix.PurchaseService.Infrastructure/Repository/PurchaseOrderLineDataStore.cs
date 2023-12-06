using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseOrderLineDataStore : BaseDataStore, IPurchaseOrderLineService
	{
		public PurchaseOrderLineDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLine()
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLine());
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineById(int id)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLine()
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLine());
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductId(id));
			return result;
		}
	}
}
