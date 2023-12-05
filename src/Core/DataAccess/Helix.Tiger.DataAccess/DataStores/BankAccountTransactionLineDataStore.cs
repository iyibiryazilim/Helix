using Helix.Models;
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
			throw new NotImplementedException();
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountId(int id)
		{
			throw new NotImplementedException();
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountIdAndBankId(int accountId, int bankId)
		{
			throw new NotImplementedException();
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankCode(string code)
		{
			throw new NotImplementedException();
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankId(int id)
		{
			throw new NotImplementedException();
		}

		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankIdAndCurrencyId(int bankId, int currencyId)
		{
			throw new NotImplementedException();
		}
	}
}
