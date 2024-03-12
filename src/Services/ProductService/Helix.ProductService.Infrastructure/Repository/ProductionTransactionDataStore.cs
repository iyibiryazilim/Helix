using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class ProductionTransactionDataStore : BaseDataStore, IProductionTransactionService
{
    ILogger<ProductionTransactionDataStore> _logger;    
    public ProductionTransactionDataStore(IConfiguration configuration,ILogger<ProductionTransactionDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransaction>(_configuraiton).GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransaction>(_configuraiton).GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransaction>(_configuraiton).GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransaction>(_configuraiton).GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransaction>(_configuraiton).GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
