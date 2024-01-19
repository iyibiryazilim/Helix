using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
    public interface ISupplierTransactionLineService
    {
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAsync(string search, string orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(string search, string orderBy, int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
    }
}
