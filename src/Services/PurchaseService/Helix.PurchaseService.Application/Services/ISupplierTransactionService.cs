using Helix.PurchaseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.PurchaseService.Application.Services
{
    public interface ISupplierTransactionService
    {
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndWarehouseAsync(string search, string orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(string search, string orderBy, int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
        public Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
    }
}
