using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class TransferTransactionDataStore : BaseDataStore, ITransferTransactionService
{
    ILogger<TransferTransactionDataStore> _logger;
    public TransferTransactionDataStore(IConfiguration configuration,ILogger<TransferTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<TransferTransaction>> GetTransferTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransaction>(_configuraiton).GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<TransferTransaction>> GetTransferTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransaction>(_configuraiton).GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransaction>(_configuraiton).GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransaction>(_configuraiton).GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<TransferTransaction>(_configuraiton).GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
