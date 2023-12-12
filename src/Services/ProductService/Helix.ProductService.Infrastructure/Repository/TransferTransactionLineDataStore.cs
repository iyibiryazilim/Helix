using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class TransferTransactionLineDataStore : BaseDataStore, ITransferTransactionLineService
{
    ILogger<TransferTransactionLineDataStore> _logger;
    public TransferTransactionLineDataStore(IConfiguration configuration,ILogger<TransferTransactionLineDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<TransferTransactionLine>> GetTransferTransactionLineByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheCodeAsync(string code)
    {
        try
        {

            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
