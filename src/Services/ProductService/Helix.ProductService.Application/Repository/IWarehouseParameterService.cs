using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;

public interface IWarehouseParameterService
{
    public Task<DataResult<IEnumerable<WarehouseParameter>>> GetWarehouseParameterByProductId(int id, string search, string orderBy, int page, int pageSize);
}
