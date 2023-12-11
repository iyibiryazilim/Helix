using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.Repository;

public class CustomerDataStore : BaseDataStore, ICustomerService
{
	ILogger<CustomerDataStore> _logger;
	public CustomerDataStore(IConfiguration configuration,ILogger<CustomerDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<Customer>> GetCustomerByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<Customer>().GetObjectAsync(new CustomerQuery(_configuraiton).GetCustomerById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			
			_logger.LogError("error");
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<Customer>().GetObjectsAsync(new CustomerQuery(_configuraiton).GetCustomerList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<Customer>> GetCustomersByCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<Customer>().GetObjectAsync(new CustomerQuery(_configuraiton).GetCustomerByCode(code));
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
