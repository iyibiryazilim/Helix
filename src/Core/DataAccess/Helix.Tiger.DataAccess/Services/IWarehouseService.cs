using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IWarehouseService
	{
		public Task<DataResult<IEnumerable<Warehouse>>> GetWarehouseList();

	}
}
