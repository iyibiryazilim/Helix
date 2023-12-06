using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface ICommercialProductService
	{
		public Task<DataResult<IEnumerable<CommercialProduct>>> GetProductList();
		public Task<DataResult<CommercialProduct>> GetProductById(int id);
		public Task<DataResult<CommercialProduct>> GetProductByCode(string code);

	}
}
