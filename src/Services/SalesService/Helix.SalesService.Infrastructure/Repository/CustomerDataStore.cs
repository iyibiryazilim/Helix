using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Repository;

public class CustomerDataStore : BaseDataStore, ICustomerService
{
	public CustomerDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<Customer>> GetCustomerByIdAsync(int id)
	{
		var result = new SqlQueryHelper<Customer>().GetObjectAsync(new CustomerQuery(_configuraiton).GetCustomerById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync()
	{
		var result = new SqlQueryHelper<Customer>().GetObjectsAsync(new CustomerQuery(_configuraiton).GetCustomerList());
		return result;
	}

	public Task<DataResult<Customer>> GetCustomersByCodeAsync(string code)
	{
		var result = new SqlQueryHelper<Customer>().GetObjectAsync(new CustomerQuery(_configuraiton).GetCustomerByCode(code));
		return result;
	}
}
