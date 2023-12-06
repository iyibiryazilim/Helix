using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IPurchaseOrderService
	{
		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrder();
		public Task<DataResult<PurchaseOrder>> GetPurchaseOrderByCode(string code);
		public Task<DataResult<PurchaseOrder>> GetPurchaseOrderById(int id);

		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentId(int id);

		public Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentCode(string code);


	}
}
