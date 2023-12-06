using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface ICustomerService
{
	public Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync();
	public Task<DataResult<Customer>> GetCustomerByIdAsync(int id);
	public Task<DataResult<Customer>> GetCustomersByCodeAsync(string code);
}
