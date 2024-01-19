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
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(string search, string orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);

	}
}
