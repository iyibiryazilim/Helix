using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IWarehouseTotalService
	{
		public Task<DataResult<IEnumerable<WarehouseTotal>>> GetProductsByWarehouseNumber(int number, string CardType, string search, string orderBy, int page, int pageSize);

	}
}
