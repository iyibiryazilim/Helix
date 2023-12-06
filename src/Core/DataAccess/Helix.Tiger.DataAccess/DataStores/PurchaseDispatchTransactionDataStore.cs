using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
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
