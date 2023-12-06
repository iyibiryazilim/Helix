using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IProductService
{
	public Task<DataResult<IEnumerable<Product>>> GetProductList();
	public Task<DataResult<Product>> GetProductById(int id);
	public Task<DataResult<Product>> GetProductByCode(string code);
}
