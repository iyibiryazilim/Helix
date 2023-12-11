using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;
public class WastageTransactionLineDataStore : BaseDataStore, IWastageTransactionLineService
{
    ILogger<WastageTransactionLineDataStore> _logger;
    public WastageTransactionLineDataStore(IConfiguration configuration,ILogger<WastageTransactionLineDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<WastageTransactionLine>> GetWastageTransactionLineByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
