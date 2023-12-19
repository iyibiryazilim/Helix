using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IProductService
	{
		public Task<DataResult<IEnumerable<Product>>> GetProductList();
		public Task<DataResult<Product>> GetProductById(int id);
		public Task<DataResult<Product>> GetProductByCode(string code);
	}
}
