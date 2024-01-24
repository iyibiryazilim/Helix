using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.PurchaseService.Infrastructure.Repository
{
    public class SupplierTransactionDataStore : BaseDataStore, ISupplierTransactionService
    {
        ILogger<SupplierTransactionDataStore> _logger;

        public SupplierTransactionDataStore(IConfiguration configuration, ILogger<SupplierTransactionDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetInputTransactionByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetInputTransactionByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetOutputTransactionByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetOutputTransactionByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(search, orderBy, currentCode, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(search, orderBy, currentId, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndWarehouseAsync(string search, string orderBy, int currentId, int warehouseNumber,string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAndWarehouseAsync(search, orderBy, currentId, warehouseNumber, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(string search, string orderBy, int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransaction>().GetObjectsAsync(new SupplierTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, orderBy, currentId, warehouseNumber,shipInfoReferenceId, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

    }
}
