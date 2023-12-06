using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface ISupplierService
	{
		public Task<DataResult<IEnumerable<Supplier>>> GetSupplierList();
		public Task<DataResult<Supplier>> GetSupplierByCode(string code);
		public Task<DataResult<Supplier>> GetSupplierById(int id);
	}
}
