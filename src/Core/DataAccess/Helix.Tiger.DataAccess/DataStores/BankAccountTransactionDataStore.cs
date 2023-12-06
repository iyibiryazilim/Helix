using Helix.SharedEntity.BaseModels;
using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class BankAccountTransactionDataStore : BaseDataStore, IBankAccountTransactionService
	{
		public BankAccountTransactionDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionByCode(string code)
		{
			var result = await new SqlQueryHelper<BankAccountTransaction>().GetObjectAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionByCode(code));
			return result;
		}

		public async Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionById(int id)
		{
			var result = await new SqlQueryHelper<BankAccountTransaction>().GetObjectAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<BankAccountTransaction>>> GetBankAccountTransactionList()
		{
			var result = await new SqlQueryHelper<BankAccountTransaction>().GetObjectsAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionList());
			return result;
		}
	}
}
