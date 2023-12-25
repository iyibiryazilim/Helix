using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface ICustomerTransactionService
{
	/// <summary>
	/// Where column_name IN (TransactionType)
	/// </summary>
	/// <param name="TransactionType"></param>
	/// <returns></returns>
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize);
	public Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize);




}
