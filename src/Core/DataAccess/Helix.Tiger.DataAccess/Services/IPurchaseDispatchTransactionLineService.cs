using Helix.SharedEntity.BaseModels;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IPurchaseDispatchTransactionLineService
	{
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineList();
		public Task<DataResult<PurchaseDispatchTransactionLine>> GetPurchaseDispatchTransactionLineById(int id);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentId(int id);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductId(int id);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheCode(string code);
		public Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheId(int id);

	}
}
