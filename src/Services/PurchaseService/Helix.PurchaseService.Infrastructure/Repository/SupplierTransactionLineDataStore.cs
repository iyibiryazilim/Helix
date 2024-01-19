using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.PurchaseService.Infrastructure.Repository
{
    public class SupplierTransactionLineDataStore : BaseDataStore, ISupplierTransactionLineService
    {
        ILogger<SupplierTransactionLineDataStore> _logger;

        public SupplierTransactionLineDataStore(IConfiguration configuration, ILogger<SupplierTransactionLineDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetInputTransactionLineByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetInputTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetOutputTransactionLineByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetOutputTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByCurrentCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByFicheCode(search, orderBy, code, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByFicheId(search, orderBy, id, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(search, orderBy, currentCode, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(search, orderBy, currentId, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
   
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAsync(string search, string orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, orderBy, currentId,warehouseNumber, TransactionType, page, pageSize));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(string search, string orderBy, int currentId, int warehouseNumber, int shipInfoReferenceId, string TransactionType, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<SupplierTransactionLine>().GetObjectsAsync(new SupplierTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAndWarehouseNumberAndShipInfoAsync(search, orderBy, currentId,warehouseNumber,shipInfoReferenceId, TransactionType, page, pageSize));
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
