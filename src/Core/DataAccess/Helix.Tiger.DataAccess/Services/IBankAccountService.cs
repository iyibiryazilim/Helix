using Helix.Models;
using Shared.Entity.Models;

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
