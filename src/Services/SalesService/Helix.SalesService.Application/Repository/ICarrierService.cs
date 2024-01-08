using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository
{
    public interface ICarrierService
    {
        public Task<DataResult<IEnumerable<Carrier>>> GetCarriersListAsync();
    }
}
