using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;

namespace Helix.PurchaseService.Application.Services
{
	public interface IPurchaseReturnDispatchTransactionLineService
	{
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionList();
		public Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetTransactionById(int id);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentCode(string code);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentId(int id);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductCode(string code);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductId(int id);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheCode(string code);
		public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheId(int id);
	}
}
