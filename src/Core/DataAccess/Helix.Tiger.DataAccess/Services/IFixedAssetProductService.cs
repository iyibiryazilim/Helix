using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IFixedAssetProductService
	{
		public Task<DataResult<IEnumerable<FixedAssetProduct>>> GetProductList();
		public Task<DataResult<FixedAssetProduct>> GetProductById(int id);
		public Task<DataResult<FixedAssetProduct>> GetProductByCode(string code);
	}
}
