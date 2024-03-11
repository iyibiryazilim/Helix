using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class WastageTransactionDataStore : BaseDataStore, IWastageTransactionService
{
    ILogger<WastageTransactionDataStore> _logger;
    public WastageTransactionDataStore(IConfiguration configuration,ILogger<WastageTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<WastageTransaction>> GetWastageTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransaction>(_configuraiton).GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<WastageTransaction>> GetWastageTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransaction>(_configuraiton).GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransaction>(_configuraiton).GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransaction>(_configuraiton).GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransaction>(_configuraiton).GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
