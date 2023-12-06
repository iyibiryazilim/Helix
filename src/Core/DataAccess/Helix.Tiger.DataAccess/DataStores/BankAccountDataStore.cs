using Helix.SharedEntity.BaseModels;
using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class BankAccountDataStore : BaseDataStore, IBankAccountService
	{
		public BankAccountDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<DataResult<BankAccount>> GetBankAccountById(int id)
		{
			var result = await new  SqlQueryHelper<BankAccount>().GetObjectAsync(new BankAccountQuery(_configuraiton).GetBankAccountById(id));
			return result;
		}

		public async Task<DataResult<IEnumerable<BankAccount>>> GetBankAccounts()
		{
			var result = await new SqlQueryHelper<BankAccount>().GetObjectsAsync(new BankAccountQuery(_configuraiton).GetBankAccountList());
			return result;
		}

		public async Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankCode(string code)
		{
			var result = await new SqlQueryHelper<BankAccount>().GetObjectsAsync(new BankAccountQuery(_configuraiton).GetBankAccountByBankCode(code));
			return result;
		}

		public async Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankId(int id)
		{
			var result = await new SqlQueryHelper<BankAccount>().GetObjectsAsync(new BankAccountQuery(_configuraiton).GetBankAccountByBankId(id));
			return result;
		}
	}
}
