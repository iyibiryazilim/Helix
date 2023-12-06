using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IEndProductService
	{
		public Task<DataResult<IEnumerable<EndProduct>>> GetProductList();
		public Task<DataResult<EndProduct>> GetProductById(int id);
		public Task<DataResult<EndProduct>> GetProductByCode(string code);
	}
}
