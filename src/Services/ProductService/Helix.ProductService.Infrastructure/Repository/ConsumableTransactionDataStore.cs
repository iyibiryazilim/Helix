using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class ConsumableTransactionDataStore : BaseDataStore, IConsumableTransactionService
{
    ILogger<ConsumableTransactionDataStore> _logger;
    public ConsumableTransactionDataStore(IConfiguration configuration,ILogger<ConsumableTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ConsumableTransaction>().GetObjectAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<ConsumableTransaction>> GetConsumableTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ConsumableTransaction>().GetObjectAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetConsumableTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ConsumableTransaction>().GetObjectsAsync(new ConsumableTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
