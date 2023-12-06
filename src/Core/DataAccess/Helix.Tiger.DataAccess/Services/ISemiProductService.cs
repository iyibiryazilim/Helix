using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface ISemiProductService
	{
		public Task<DataResult<IEnumerable<SemiProduct>>> GetProductList();
		public Task<DataResult<SemiProduct>> GetProductById(int id);
		public Task<DataResult<SemiProduct>> GetProductByCode(string code);
	}
}
