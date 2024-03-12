using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;
public class InCountingTransactionLineDataStore : BaseDataStore, IInCountingTransactionLineService
{
    ILogger<InCountingTransactionLineDataStore> _logger;
    public InCountingTransactionLineDataStore(IConfiguration configuration,ILogger<InCountingTransactionLineDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<InCountingTransactionLine>> GetInCountingTransactionLineByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesAsync()
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductCodeAsync(string code)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
        }
        catch (Exception ex)
        {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
        }
    }

    public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<InCountingTransactionLine>(_configuraiton).GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
