using Helix.Models;
using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class BankAccountDataStore : BaseDataStore, IBankAccountService
	{
		public BankAccountDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<BankAccount>> GetBankAccountById(int id)
		{
			var result = new SqlQueryHelper<BankAccount>().GetObjectAsync(new BankAccountQuery(_configuraiton).GetBankAccountById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccounts()
		{
			var result = new SqlQueryHelper<IEnumerable<BankAccount>>().GetObjectAsync(new BankAccountQuery(_configuraiton).GetBankAccountList());
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankCode(string code)
		{
			var result = new SqlQueryHelper<IEnumerable<BankAccount>>().GetObjectAsync(new BankAccountQuery(_configuraiton).GetBankAccountByBankCode(code));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankId(int id)
		{
			var result = new SqlQueryHelper<IEnumerable<BankAccount>>().GetObjectAsync(new BankAccountQuery(_configuraiton).GetBankAccountByBankId(id));
			return result;
		}
	}
}
