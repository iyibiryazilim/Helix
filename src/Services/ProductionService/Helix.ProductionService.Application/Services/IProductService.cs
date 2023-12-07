using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Domain.Models.BaseModels;

namespace Helix.ProductionService.Application.Services;

public interface IProductService
{
	public Task<DataResult<IEnumerable<Product>>> GetProductList();
	public Task<DataResult<Product>> GetProductById(int id);
	public Task<DataResult<Product>> GetProductByCode(string code);
}
