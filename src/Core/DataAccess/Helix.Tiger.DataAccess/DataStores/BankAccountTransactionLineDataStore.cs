using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class BankAccountTransactionLineDataStore : BaseDataStore, IBankAccountTransactionLineService
	{
		public BankAccountTransactionLineDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<BankAccountTransactionLine>> GetBankAccountTransactionLineById(int id)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLines()
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineList());
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountId(int id)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineByBankAccountId(id));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountIdAndBankId(int accountId, int bankId)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineByBankAccountIdAndBankId(accountId, bankId));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankCode(string code)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineByBankCode(code));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankId(int id)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineByBankId(id));
			return result;
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankIdAndCurrencyId(int bankId, int currencyId)
		{
			var result = new SqlQueryHelper<BankAccountTransactionLine>().GetObjectsAsync(new BankAccountTransactionLineQuery(_configuraiton).GetBankAccountTransactionLineByBankIdAndCurrencyId(bankId, currencyId));
			return result;
		}
	}
}
