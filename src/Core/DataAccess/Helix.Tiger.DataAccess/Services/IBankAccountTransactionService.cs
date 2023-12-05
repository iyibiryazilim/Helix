using Helix.Models;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IBankAccountTransactionService
	{
		public Task<DataResult<IEnumerable<BankAccountTransaction>>> GetBankAccountTransactionList();
		public Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionById(int id);
		public Task<DataResult<BankAccountTransaction>> GetBankAccountTransactionByCode(string code);

	}
}
