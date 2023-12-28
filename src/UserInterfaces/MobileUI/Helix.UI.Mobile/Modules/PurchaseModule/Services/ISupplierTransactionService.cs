using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface ISupplierTransactionService
	{
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentIdAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentIdAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentIdAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentCodeAsync(HttpClient httpClient, string search, SupplierTransactionOrderBy orderBy, string code, int page, int pageSize);
	}
}
