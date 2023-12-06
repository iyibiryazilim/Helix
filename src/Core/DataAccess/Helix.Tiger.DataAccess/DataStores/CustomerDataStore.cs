using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

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
