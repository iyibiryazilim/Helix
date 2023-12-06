using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IRawProductService
	{
		public Task<DataResult<IEnumerable<RawProduct>>> GetProductList();
		public Task<DataResult<RawProduct>> GetProductById(int id);
		public Task<DataResult<RawProduct>> GetProductByCode(string code);
	}
}
