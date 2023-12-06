using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;


namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseDispatchTransactionDataStore : BaseDataStore, IPurchaseDispatchTransactionService
	{
		public PurchaseDispatchTransactionDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionByCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentCode(string code)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentId(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
			return result;
		}

		public async Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionById(int id)
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionList()
		{
			var result = await  new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionList());
			return result;
		}
	}
}
