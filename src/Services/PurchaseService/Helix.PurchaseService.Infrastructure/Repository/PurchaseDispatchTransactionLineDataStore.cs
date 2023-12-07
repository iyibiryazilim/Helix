using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;


namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseDispatchTransactionLineDataStore : BaseDataStore, IPurchaseDispatchTransactionLineService
	{
		public PurchaseDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentId(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheId(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			return result;
		}

		public async Task<DataResult<PurchaseDispatchTransactionLine>> GetPurchaseDispatchTransactionLineById(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductId(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineList()
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
			return result;
		}
	}
}
