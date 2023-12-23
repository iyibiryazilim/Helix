using Helix.FinanceService.Domain.Models;

namespace Helix.FinanceService.Application.Repository;

public interface IRepository<T> where T : class
{
    Task<DataResult<IEnumerable<T>>> GetAllAsync();
    Task<DataResult<T>> GetByIdAsync(int referenceId);
}
