using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class OutCountingTransactionLineDataStore : BaseDataStore, IOutCountingTransactionLineService
{
    ILogger<OutCountingTransactionLineDataStore> _logger;
    public OutCountingTransactionLineDataStore(IConfiguration configuration,ILogger<OutCountingTransactionLineDataStore> logger) : base(configuration)
    {
        _logger = logger;   
    }

    public async Task<DataResult<OutCountingTransactionLine>> GetOutCountingTransactionLineByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
