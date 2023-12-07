
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;

using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class SemiProductDataStore : BaseDataStore, ISemiProductService
	{
		public SemiProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<SemiProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductByCode(code));
			return result;
		}

		public Task<DataResult<SemiProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectAsync(new SemiProductQuery(_configuraiton).GetSemiProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<SemiProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<SemiProduct>().GetObjectsAsync(new SemiProductQuery(_configuraiton).GetSemiProductList());
			return result;
		}
	}
}
