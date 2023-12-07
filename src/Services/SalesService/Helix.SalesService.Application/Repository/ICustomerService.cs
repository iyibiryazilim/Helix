using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface ICustomerService
{
	public Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync();
	public Task<DataResult<Customer>> GetCustomerByIdAsync(int id);
	public Task<DataResult<Customer>> GetCustomersByCodeAsync(string code);
}
