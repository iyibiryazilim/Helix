using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Services
{
	public interface ISupplierTransactionLineService
	{
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheIdAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheCodeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, SupplierTransactionLineOrderBy orderBy, string code, int page, int pageSize);
	}
}
