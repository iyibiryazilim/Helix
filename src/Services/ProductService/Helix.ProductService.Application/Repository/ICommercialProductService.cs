using Helix.Product.Service.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface ICommercialProductService
	{
		public Task<DataResult<IEnumerable<CommercialProduct>>> GetProductList();
		public Task<DataResult<CommercialProduct>> GetProductById(int id);
		public Task<DataResult<CommercialProduct>> GetProductByCode(string code);

	}
}
