using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class InCountingTransactionDataStore : BaseDataStore, IInCountingTransactionService
{
    ILogger<InCountingTransactionDataStore> _logger;    
    public InCountingTransactionDataStore(IConfiguration configuration,ILogger<InCountingTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<InCountingTransaction>> GetInCountingTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<InCountingTransaction>> GetInCountingTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
