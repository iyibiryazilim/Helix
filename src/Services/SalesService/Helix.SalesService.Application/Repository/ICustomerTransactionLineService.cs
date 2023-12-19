using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository
{
	public interface ICustomerTransactionLineService
	{
		/// <summary>
		/// Where column_name IN (TransactionType)
		/// </summary>
		/// <param name="TransactionType"></param>
		/// <returns></returns>
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string currentCode, string TransactionType);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(int currentId, string TransactionType);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCode(string code);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentId(int id);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCode(string code);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentId(int id);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheId(int id);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCode(string code);

	}
}
