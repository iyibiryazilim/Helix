using Helix.FinanceService.Application.Repository;
using Helix.FinanceService.Domain.Models;

namespace Helix.FinanceService.Application.Services;

public interface ICustomerService
{
    public Task<DataResult<IEnumerable<Customer>>> GetCustomersAsync(string search, string orderBy, int page, int pageSize);
    public Task<DataResult<Customer>> GetCustomerByIdAsync(int id);
    public Task<DataResult<Customer>> GetCustomersByCodeAsync(string code);
}
