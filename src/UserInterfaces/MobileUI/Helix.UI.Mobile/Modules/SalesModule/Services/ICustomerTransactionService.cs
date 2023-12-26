using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ICustomerTransactionService
    {
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize);
	}
}
