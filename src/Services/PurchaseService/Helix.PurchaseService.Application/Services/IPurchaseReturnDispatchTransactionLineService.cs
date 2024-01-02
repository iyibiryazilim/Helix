using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseReturnDispatchTransactionLineService
	{
	 

		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineList(string search, string orderBy, int page, int pageSize);
		public Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetTransactionLineById(int id);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByProductCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByProductId(string search, string orderBy, int id, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize);
	}
}
