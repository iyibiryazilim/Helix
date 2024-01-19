using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
	public interface ICustomerTransactionLineService
    {
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient,string search, CustomerTransactionLineOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize);

        public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize);

        public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize);
	}
}
