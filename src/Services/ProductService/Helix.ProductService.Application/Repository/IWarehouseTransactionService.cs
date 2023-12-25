using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;

public interface IWarehouseTransactionService
{
	public Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseNumberAsync(int number, string search, string orderBy, int currentPage, int pageSize);
	public Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseReferenceIdAsync(int id, string search, string orderBy, int currentPage, int pageSize);
	public Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseNumberAsync(int number, string search, string orderBy, int currentPage, int pageSize);
	public Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseReferenceIdAsync(int id, string search, string orderBy, int currentPage, int pageSize);
}
