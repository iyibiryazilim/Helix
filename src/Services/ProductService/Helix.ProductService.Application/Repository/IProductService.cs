using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IProductService
	{
		public Task<DataResult<IEnumerable<Product>>> GetProductList(string search, string groupCode,string orderBy, int page, int pageSize);
		public Task<DataResult<Product>> GetProductById(int id);
		public Task<DataResult<Product>> GetProductByCode(string code);
		public Task<DataResult<IEnumerable<ProductGroup>>> GetProductGroupCodes();
	}
}
