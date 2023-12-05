using Helix.Models;
using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class BankAccountTransactionDataStore : BaseDataStore, IBankAccountTransactionService
	{
		public BankAccountTransactionDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionByCode(string code)
		{
			var result = new SqlQueryHelper<BankAccountTransaction>().GetObjectAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionByCode(code));
			return result;
		}

		public Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionById(int id)
		{
			var result = new SqlQueryHelper<BankAccountTransaction>().GetObjectAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransaction>>> GetBankAccountTransactionList()
		{
			var result = new SqlQueryHelper<BankAccountTransaction>().GetObjectsAsync(new BankAccountTransactionQuery(_configuraiton).GetBankAccountTransactionList());
			return result;
		}
	}
}
