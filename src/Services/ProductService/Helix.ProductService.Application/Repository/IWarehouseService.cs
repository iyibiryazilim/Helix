

using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IWarehouseService
	{
		public Task<DataResult<IEnumerable<Warehouse>>>GetWarehouseList();

	}
}
