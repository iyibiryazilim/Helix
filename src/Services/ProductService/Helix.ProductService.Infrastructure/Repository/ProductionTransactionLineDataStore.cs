using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class ProductionTransactionLineDataStore : BaseDataStore, IProductionTransactionLineService
{
    ILogger<ProductionTransactionLineDataStore> _logger;    
    public ProductionTransactionLineDataStore(IConfiguration configuration,ILogger<ProductionTransactionLineDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<ProductionTransactionLine>> GetProductionTransactionLineByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
