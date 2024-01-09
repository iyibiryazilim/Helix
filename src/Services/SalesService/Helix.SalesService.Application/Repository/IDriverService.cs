using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IDriverService
{
    public  Task<DataResult<IEnumerable<Driver>>> GetDriversListAsync();
}
