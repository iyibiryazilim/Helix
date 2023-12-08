using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;
public interface ITransferTransactionService
{
	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsAsync();
	public Task<DataResult<TransferTransaction>> GetTransferTransactionByIdAsync(int id);
	public Task<DataResult<TransferTransaction>> GetTransferTransactionByCode(string code);
	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentCodeAsync(string code);
}
