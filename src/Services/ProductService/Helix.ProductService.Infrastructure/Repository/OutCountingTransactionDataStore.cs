using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class OutCountingTransactionDataStore : BaseDataStore, IOutCountingTransactionService
{
    ILogger<OutCountingTransactionDataStore> _logger;   
    public OutCountingTransactionDataStore(IConfiguration configuration,ILogger<OutCountingTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransaction>(_configuraiton).GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransaction>(_configuraiton).GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransaction>(_configuraiton).GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransaction>(_configuraiton).GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransaction>(_configuraiton).GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
