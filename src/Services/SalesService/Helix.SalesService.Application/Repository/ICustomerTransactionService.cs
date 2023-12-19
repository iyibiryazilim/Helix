using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface ICustomerTransactionService
{
	/// <summary>
	/// Where column_name IN (TransactionType)
	/// </summary>
	/// <param name="TransactionType"></param>
	/// <returns></returns>
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string currentCode,string TransactionType);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(int currentId, string TransactionType);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCode(string code);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentId(int id);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCode(string code);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentId(int id);


}
