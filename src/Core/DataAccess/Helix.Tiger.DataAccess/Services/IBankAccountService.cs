using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IBankAccountService
	{
		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccounts();
		public Task<DataResult<BankAccount>> GetBankAccountById(int id);
		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankId(int id);
		public Task<DataResult<IEnumerable<BankAccount>>> GetBankAccountsByBankCode(string code);
	}
}
