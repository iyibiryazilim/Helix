using Helix.FinanceService.Application.Services;
using Helix.FinanceService.Domain.Models;
using Helix.FinanceService.Infrastructure.BaseRepository;
using Helix.FinanceService.Infrastructure.Helpers;
using Helix.FinanceService.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static Helix.FinanceService.Infrastructure.Queries.CustomerQuery;

namespace Helix.FinanceService.Infrastructure.Repository;

public class CustomerDataStore : BaseDataStore, ICustomerService
{
    ILogger<CustomerDataStore> _logger;
    public CustomerDataStore(IConfiguration configuration, ILogger<CustomerDataStore> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<DataResult<Customer>> GetCustomerByIdAsync(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<Customer>().GetObjectAsync(new CustomerQuery(_configuraiton).GetCustomerById(id));
            _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
            throw;
        }
    }

    public async Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync(string search = "", string orderBy = CustomerOrderBy.CustomerNameDesc, int page = 0, int pageSize = 20)
    {
        try
        {
            var result = await new SqlQueryHelper<Customer>().GetObjectsAsync(new CustomerQuery(_configuraiton).GetCustomerList(search, orderBy, page, pageSize));
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
