using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IBankAccountTransactionLineService
	{
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLines();
		public Task<DataResult<BankAccountTransactionLine>> GetBankAccountTransactionLineById(int id);
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankId(int id);
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankCode(string code);
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountId(int id);
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankAccountIdAndBankId(int accountId, int bankId);
		public Task<DataResult<IEnumerable<BankAccountTransactionLine>>> GetBankAccountTransactionLinesByBankIdAndCurrencyId(int bankId, int currencyId); 
	}
}
