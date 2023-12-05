using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseReturnDispatchTransactionLineDataStore : BaseDataStore, IPurchaseReturnDispatchTransactionLineService
	{
		public PurchaseReturnDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			return result;
		}

		public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetTransactionById(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductCode(string code)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductId(int id)
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionList()
		{
			var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
			return result;
		}
	}
}
