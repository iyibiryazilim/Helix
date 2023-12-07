using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface ISupplierService
	{
		public Task<DataResult<IEnumerable<Supplier>>> GetSupplierList();
		public Task<DataResult<Supplier>> GetSupplierByCode(string code);
		public Task<DataResult<Supplier>> GetSupplierById(int id);
	}
}
