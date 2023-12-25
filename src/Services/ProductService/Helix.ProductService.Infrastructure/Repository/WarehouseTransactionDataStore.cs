using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class WarehouseTransactionDataStore : BaseDataStore, IWarehouseTransactionService
{
	private readonly ILogger<WarehouseTransactionDataStore> _logger;
	public WarehouseTransactionDataStore(IConfiguration configuration, ILogger<WarehouseTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseNumberAsync(int number, string search, string orderBy, int currentPage, int pageSize)
	{
		try
		{

			var result = await new SqlQueryHelper<WarehouseTransaction>().GetObjectsAsync(new WarehouseTransactionQuery(_configuraiton).GetInputTransactionByWarehouseNumber(number, search, orderBy, currentPage, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseReferenceIdAsync(int id, string search, string orderBy, int currentPage, int pageSize)
	{
		try
		{
			var result = await new SqlQueryHelper<WarehouseTransaction>().GetObjectsAsync(new WarehouseTransactionQuery(_configuraiton).GetInputTransactionByWarehouseReferenceId(id, search, orderBy, currentPage, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseNumberAsync(int number, string search, string orderBy, int currentPage, int pageSize)
	{
		try
		{
			var result = await new SqlQueryHelper<WarehouseTransaction>().GetObjectsAsync(new WarehouseTransactionQuery(_configuraiton).GetOutputTransactionByWarehouseNumber(number, search, orderBy, currentPage, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseReferenceIdAsync(int id, string search, string orderBy, int currentPage, int pageSize)
	{
		try
		{
			var result = await new SqlQueryHelper<WarehouseTransaction>().GetObjectsAsync(new WarehouseTransactionQuery(_configuraiton).GetOutputTransactionByWarehouseReferenceId(id, search, orderBy, currentPage, pageSize));
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
